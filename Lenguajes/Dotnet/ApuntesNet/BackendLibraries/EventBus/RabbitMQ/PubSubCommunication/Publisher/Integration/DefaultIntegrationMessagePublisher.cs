using System.Diagnostics;
using PubSubCommunication.Messages;

namespace PubSubCommunication.Publisher.Integration;

public class DefaultIntegrationMessagePublisher(
    IExternalMessagePublisher<IntegrationMessage> externalPublisher
) : IIntegrationMessagePublisher
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
        IntegrationMessage? integrationMessage = IntegrationMessageMapper.MapToMessage(
            message,
            calculateMetadata,
            activity?.SpanId.ToString()
        );

        await externalPublisher.Publish(integrationMessage, routingKey, cancellationToken);

        TracerPublisher.TracePublishTags(
            activity,
            routingKey,
            calculateMetadata,
            integrationMessage
        );
        activity?.SetStatus(ActivityStatusCode.Ok);
    }

    private Metadata CalculateMetadata(Metadata? metadata)
    {
        return metadata ?? new Metadata(Guid.NewGuid().ToString(), DateTime.UtcNow);
    }
}
