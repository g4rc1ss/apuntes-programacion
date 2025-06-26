namespace DeferredExecutionYield.ExplicitEnumerator.AsyncEnumerableClass;

internal class ExplicitAsyncEnumerator : IAsyncEnumerator<int>
{
    public int Current { get; private set; }

    public async ValueTask DisposeAsync()
    {
        await Task.Delay(1);
        GC.SuppressFinalize(this);
    }

    public async ValueTask<bool> MoveNextAsync()
    {
        if (Current < 100)
        {
            Current++;
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }
}
