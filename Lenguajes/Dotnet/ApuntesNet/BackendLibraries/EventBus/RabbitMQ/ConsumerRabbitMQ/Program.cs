using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PubSubCommunication;
using PubSubCommunication.Consumers.Handler;
using PubSubCommunication.Messages;

using PubSubRabbitMQ;


IHostBuilder builder = Host.CreateDefaultBuilder(args);

builder.ConfigureAppConfiguration(configuration =>
{
});

builder.ConfigureServices((hostBuilder, serviceCollection) =>
{
    serviceCollection.AddHandlersInAssembly<Program>();
    serviceCollection.AddRabbitMQ(hostBuilder.Configuration);
    serviceCollection.AddRabbitMqConsumer<IntegrationMessage>();

    serviceCollection.AddOpenTelemetry()
        .WithMetrics()
        .WithLogging()
        .WithTracing(tracer => tracer.AddSource(nameof(IMessageHandler)));
});


IHost app = builder.Build();

IHostEnvironment environment = app.Services.GetRequiredService<IHostEnvironment>();
IConfiguration config = app.Services.GetRequiredService<IConfiguration>();

Console.WriteLine($"{environment.EnvironmentName}");
Console.WriteLine(config["AppName"]);

await app.RunAsync();