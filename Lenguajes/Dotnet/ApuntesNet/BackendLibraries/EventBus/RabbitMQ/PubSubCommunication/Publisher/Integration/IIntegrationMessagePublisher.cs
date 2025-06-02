using PubSubCommunication.Messages;

namespace PubSubCommunication.Publisher.Integration;

public interface IIntegrationMessagePublisher
{
    Task Publish(
        object message,
        Metadata? metadata = null,
        string? routingKey = null,
        CancellationToken cancellationToken = default
    );
}
