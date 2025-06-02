using System.Diagnostics;
using System.Reflection;
using PubSubCommunication.Messages;

namespace PubSubCommunication.Publisher.Domain;

public class DomainMessageMapper
{
    public static DomainMessage MapToMessage(object message, Metadata metadata, string parentId)
    {
        if (message is IntegrationMessage)
        {
            throw new ArgumentException(
                "Message should not be of type DomainMessage, it should be a plain type"
            );
        }

        MethodInfo? buildWrapperMethodInfo = typeof(DomainMessageMapper).GetMethod(
            nameof(ToTypedIntegrationEvent),
            BindingFlags.Static | BindingFlags.NonPublic
        );

        MethodInfo? buildWrapperGenericMethodInfo = buildWrapperMethodInfo?.MakeGenericMethod(
            [message.GetType()]
        );
        MessageDiagnosticTraces? traces = new()
        {
            TraceId = Activity.Current!.TraceId.ToString(),
            SpanId = Activity.Current!.SpanId.ToString(),
            ParentId = parentId,
        };
        object? wrapper = buildWrapperGenericMethodInfo?.Invoke(null, [message, metadata, traces]);
        return (wrapper as DomainMessage)!;
    }

    private static DomainMessage<T> ToTypedIntegrationEvent<T>(
        T message,
        Metadata metadata,
        MessageDiagnosticTraces traces
    )
    {
        return new DomainMessage<T>(
            Guid.NewGuid().ToString(),
            typeof(T).Name,
            traces,
            message,
            metadata
        );
    }
}
