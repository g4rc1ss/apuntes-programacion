using Microsoft.Extensions.Logging;
using PubSubCommunication.Consumers.Handler;
using PubSubCommunication.Messages;
using SharedTypesRabbit;

namespace ConsumerRabbitMQ.Handler;

public class ConsumerRabbitMqPrueba(ILogger<ConsumerRabbitMqPrueba> logger)
    : IIntegrationMessageHandler<PruebaMensajeRabbit>
{
    public Task Handle(
        IntegrationMessage<PruebaMensajeRabbit> message,
        CancellationToken cancelToken = default
    )
    {
        logger.LogInformation("El mensaje es: {@Message}", message?.Content);
        return Task.CompletedTask;
    }
}
