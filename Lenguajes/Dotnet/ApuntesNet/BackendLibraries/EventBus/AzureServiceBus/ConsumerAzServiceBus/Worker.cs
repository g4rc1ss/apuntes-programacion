using Azure.Messaging.ServiceBus;

namespace ConsumerAzServiceBus;

public class Worker(ILogger<Worker> logger, IConfiguration configuration, ServiceBusClient client)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await ListenServiceBus();
    }

    private async Task ListenServiceBus()
    {
        string? queueName = configuration["ServiceBusConfig:QueueName"];
        ServiceBusProcessor? processor = client.CreateProcessor(queueName);

        try
        {
            processor.ProcessMessageAsync += TranslateTextAsync;
            processor.ProcessErrorAsync += ErrorMessageAsync;

            await processor.StartProcessingAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
        }
    }

    private Task TranslateTextAsync(ProcessMessageEventArgs args)
    {
        string messageBody = args.Message.Body.ToString();
        logger.LogInformation("Recibimos mensaje {@Message}", messageBody);

        return Task.CompletedTask;
    }

    private Task ErrorMessageAsync(ProcessErrorEventArgs args)
    {
        return Task.CompletedTask;
    }
}
