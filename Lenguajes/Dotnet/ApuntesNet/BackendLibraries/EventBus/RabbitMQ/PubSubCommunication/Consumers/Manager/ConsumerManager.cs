namespace PubSubCommunication.Consumers.Manager;

public class ConsumerManager<TMessage> : IConsumerManager<TMessage>
{
    private CancellationTokenSource cancellationTokenSource;

    public ConsumerManager()
    {
        cancellationTokenSource = new CancellationTokenSource();
    }

    public CancellationToken GetCancellationToken()
    {
        return cancellationTokenSource.Token;
    }

    public void RestartExecution()
    {
        CancellationTokenSource? cancellationTokenSource = this.cancellationTokenSource;
        this.cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
    }

    public void StopExecution()
    {
        cancellationTokenSource.Cancel();
    }
}
