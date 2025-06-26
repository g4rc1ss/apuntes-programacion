namespace PubSubCommunication.Consumers.Handler;

public interface IMessageHandlerRegistry
{
    IEnumerable<IMessageHandler> GetMessageHandlersForType(
        Type messageHandlerType,
        Type messageType
    );
}
