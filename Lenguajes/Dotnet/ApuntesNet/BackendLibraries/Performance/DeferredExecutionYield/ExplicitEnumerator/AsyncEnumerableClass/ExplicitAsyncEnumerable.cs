namespace DeferredExecutionYield.ExplicitEnumerator.AsyncEnumerableClass;

internal class ExplicitAsyncEnumerable : IAsyncEnumerable<int>
{
    public IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return new ExplicitAsyncEnumerator();
    }
}
