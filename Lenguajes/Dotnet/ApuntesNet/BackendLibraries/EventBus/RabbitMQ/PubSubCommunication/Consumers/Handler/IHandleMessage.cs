using PubSubCommunication.Messages;

namespace PubSubCommunication.Consumers.Handler;

public interface IHandleMessage
{
    Task Handle(IMessage message, CancellationToken cancellationToken = default);
}
