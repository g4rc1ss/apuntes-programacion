using System.Collections.Concurrent;

namespace PubSubCommunication.Consumers.Handler;

public class MessageHandlerRegistry(IEnumerable<IMessageHandler> messageHandlers)
    : IMessageHandlerRegistry
{
    private readonly ConcurrentDictionary<string, IEnumerable<IMessageHandler>> _cachedHandlers =
        new();

    public IEnumerable<IMessageHandler> GetMessageHandlersForType(
        Type messageHandlerType,
        Type messageType
    )
    {
        string? key = $"{messageHandlerType}-{messageType}";
        if (_cachedHandlers.TryGetValue(key, out IEnumerable<IMessageHandler>? existingHandlers))
        {
            return existingHandlers;
        }

        IList<IMessageHandler>? handlers = GetMessageHandlersInternal(messageHandlerType);
        _cachedHandlers.AddOrUpdate(key, handlers, (_, _) => handlers);

        return handlers;
    }

    private IList<IMessageHandler> GetMessageHandlersInternal(Type messageHandlerType)
    {
        return
        [
            .. messageHandlers
                .Where(messageHandler =>
                    messageHandler.GetType().GetInterfaces().Contains(messageHandlerType)
                )
                .Distinct(),
        ];
    }
}
