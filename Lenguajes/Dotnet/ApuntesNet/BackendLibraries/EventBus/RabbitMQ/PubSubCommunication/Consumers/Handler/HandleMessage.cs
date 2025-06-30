using System.Diagnostics;
using System.Reflection;
using PubSubCommunication.Messages;

namespace PubSubCommunication.Consumers.Handler;

public class HandleMessage(IMessageHandlerRegistry messageHandlerRegistry) : IHandleMessage
{
    public async Task Handle(IMessage message, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(message);

        Type? messageType = message.GetType();
        Type? handlerType = typeof(IMessageHandler<>).MakeGenericType(messageType);
        IEnumerable<IMessageHandler>? handlers = messageHandlerRegistry.GetMessageHandlersForType(
            handlerType,
            messageType
        );

        foreach (IMessageHandler? handler in handlers)
        {
            Type? messageHandlerType = handler.GetType();

            MethodInfo? handle = messageHandlerType
                .GetMethods()
                .Where(methodInfo => methodInfo.Name == nameof(IMessageHandler<object>.Handle))
                .FirstOrDefault(info =>
                    info.GetParameters()
                        .Select(parameter => parameter.ParameterType)
                        .Contains(message.GetType())
                );
            if (handle != null)
            {
                ActivityTraceId traceId = default;
                if (!string.IsNullOrEmpty(message?.Traces?.TraceId))
                {
                    traceId = ActivityTraceId.CreateFromString(message?.Traces?.TraceId);
                }

                ActivitySpanId spanId = default;
                if (!string.IsNullOrEmpty(message?.Traces?.SpanId))
                {
                    spanId = ActivitySpanId.CreateFromString(message?.Traces?.SpanId);
                }

                using ActivitySource? tracingConsumer = new(nameof(IMessageHandler));
                using Activity? activity = tracingConsumer.CreateActivity(
                    "Llamar handler",
                    ActivityKind.Consumer
                );
                activity?.SetParentId(traceId, spanId, ActivityTraceFlags.Recorded);
                activity?.AddTag("Handler", handler);
                activity?.Start();

                await (Task)handle.Invoke(handler, [message, cancellationToken])!;

                activity?.SetStatus(ActivityStatusCode.Ok);
            }
        }
    }
}
