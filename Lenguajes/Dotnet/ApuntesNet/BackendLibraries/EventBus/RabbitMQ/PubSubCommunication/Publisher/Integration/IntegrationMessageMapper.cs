using System.Diagnostics;
using System.Reflection;
using PubSubCommunication.Messages;

namespace PubSubCommunication.Publisher.Integration;

public static class IntegrationMessageMapper
{
    internal static IntegrationMessage MapToMessage(
        object message,
        Metadata metadata,
        string parentId
    )
    {
        if (message is IntegrationMessage)
        {
            throw new ArgumentException("Message should not be of type IntegrationMessage");
        }

        MethodInfo? buildWrapperMethodInfo = typeof(IntegrationMessageMapper).GetMethod(
            nameof(ToTypedIntegrationEvent),
            BindingFlags.Static | BindingFlags.NonPublic
        );

        MethodInfo? buildWrapperGenericMethodInfo = buildWrapperMethodInfo?.MakeGenericMethod(
            [message.GetType()]
        );
        MessageDiagnosticTraces? traces = new()
        {
            TraceId = Activity.Current?.TraceId.ToString() ?? string.Empty,
            SpanId = Activity.Current?.SpanId.ToString() ?? string.Empty,
            ParentId = parentId,
        };
        object? wrapper = buildWrapperGenericMethodInfo?.Invoke(null, [message, metadata, traces]);
        return (wrapper as IntegrationMessage)!;
    }

    private static IntegrationMessage<T> ToTypedIntegrationEvent<T>(
        T message,
        Metadata metadata,
        MessageDiagnosticTraces traces
    )
    {
        return new IntegrationMessage<T>(
            Guid.NewGuid().ToString(),
            typeof(T).Name,
            traces,
            message,
            metadata
        );
    }
}
