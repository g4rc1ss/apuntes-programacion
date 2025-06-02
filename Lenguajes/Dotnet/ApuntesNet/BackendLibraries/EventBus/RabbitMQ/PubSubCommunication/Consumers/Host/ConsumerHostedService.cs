using Microsoft.Extensions.Hosting;
using PubSubCommunication.Consumers.Manager;

namespace PubSubCommunication.Consumers.Host;

public class ConsumerHostedService<TMessage>(
    IConsumerManager<TMessage> consumerManager,
    IMessageConsumer<TMessage> messageConsumer
) : IHostedService
{
    private readonly CancellationTokenSource _stoppingCancellationTokenSource = new();
    private Task? executingTask;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        executingTask = ConsumeMessages(_stoppingCancellationTokenSource.Token);
        return executingTask.IsCompleted ? executingTask : Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _stoppingCancellationTokenSource.Cancel();
        consumerManager.StopExecution();
        return Task.CompletedTask;
    }

    private async Task ConsumeMessages(CancellationToken cancellationToken)
    {
        CancellationToken ct = consumerManager.GetCancellationToken();
        if (ct.IsCancellationRequested)
        {
            // break;
        }

        try
        {
            await messageConsumer.StartAsync(cancellationToken);
            await Task.Delay(1000, cancellationToken);
        }
        catch (OperationCanceledException) { }
    }
}
