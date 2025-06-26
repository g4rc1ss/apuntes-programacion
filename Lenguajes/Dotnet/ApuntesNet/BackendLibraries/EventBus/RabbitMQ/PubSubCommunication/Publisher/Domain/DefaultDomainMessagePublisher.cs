using System.Diagnostics;
using PubSubCommunication.Messages;

namespace PubSubCommunication.Publisher.Domain;

public class DefaultDomainMessagePublisher(
    IExternalMessagePublisher<DomainMessage> externalPublisher
) : IDomainMessagePublisher
{
    public async Task Publish(
        object message,
        Metadata? metadata = null,
        string? routingKey = null,
        CancellationToken cancellationToken = default
    )
    {
        using ActivitySource? tracingConsumer = new(nameof(IExternalMessagePublisher<IMessage>));
        using Activity? activity = tracingConsumer.CreateActivity(
            "Publicar mensaje",
            ActivityKind.Consumer
        );

        Metadata? calculateMetadata = CalculateMetadata(metadata);

        activity?.Start();
        DomainMessage? domainMessage = DomainMessageMapper.MapToMessage(
            message,
            calculateMetadata,
            activity?.SpanId.ToString()
        );

        await externalPublisher.Publish(domainMessage, routingKey, cancellationToken);

        TracerPublisher.TracePublishTags(activity, routingKey, calculateMetadata, domainMessage);
        activity.SetStatus(ActivityStatusCode.Ok);
    }

    private Metadata CalculateMetadata(Metadata? metadata)
    {
        return metadata ?? new Metadata(Guid.NewGuid().ToString(), DateTime.UtcNow);
    }
}
