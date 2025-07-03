using Azure.Messaging.ServiceBus;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

using IHost host = builder.Build();
IConfiguration configuration = host.Services.GetRequiredService<IConfiguration>();
ServiceBusClient client = host.Services.GetRequiredService<ServiceBusClient>();

string? queuename = configuration["ServiceBusConfig:QueueName"];
ServiceBusSender? sender = client.CreateSender(queuename);

ServiceBusMessage message = new("Mensaje de prueba de envio en AZ Service Bus");

await sender.SendMessageAsync(message, CancellationToken.None);
