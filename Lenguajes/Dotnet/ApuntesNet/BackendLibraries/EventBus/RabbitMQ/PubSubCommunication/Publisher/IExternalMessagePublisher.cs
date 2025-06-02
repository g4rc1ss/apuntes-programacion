using PubSubCommunication.Messages;

namespace PubSubCommunication.Publisher;

public interface IExternalMessagePublisher<in TMessage>
    where TMessage : IMessage
{
    Task Publish(
        TMessage message,
        string? routingKey = null,
        CancellationToken cancellationToken = default
    );
}
