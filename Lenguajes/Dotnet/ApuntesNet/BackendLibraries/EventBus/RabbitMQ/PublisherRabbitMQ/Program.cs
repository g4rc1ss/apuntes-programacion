using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PubSubCommunication;
using PubSubCommunication.Consumers.Handler;
using PubSubCommunication.Messages;
using PubSubCommunication.Publisher.Integration;
using PubSubRabbitMQ;
using SharedTypesRabbit;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);

hostBuilder.ConfigureAppConfiguration(x => { });

hostBuilder.ConfigureServices(
    (host, serviceCollection) =>
    {
        serviceCollection.AddHandlersInAssembly<Program>();
        serviceCollection.AddRabbitMq(host.Configuration);
        serviceCollection.AddRabbitMqPublisher<IntegrationMessage>();

        serviceCollection
            .AddOpenTelemetry()
            .WithMetrics()
            // .WithLogging()
            .WithTracing(tracer => tracer.AddSource(nameof(IMessageHandler)));
    }
);

using IHost host = hostBuilder.Build();

// Publish message
IIntegrationMessagePublisher integrationMessage =
    host.Services.GetRequiredService<IIntegrationMessagePublisher>();

PruebaMensajeRabbit message = new("Hola, este es el mensaje", Guid.NewGuid());
await integrationMessage.Publish(message, null, "pruebaRabbitMQ.create", CancellationToken.None);
