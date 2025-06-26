namespace DeferredExecutionYield.YieldEnumerator;

internal class YieldExecution
{
    public IEnumerable<int> GetEnumerableWithYield()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return i;
        }
    }

    public async IAsyncEnumerable<int> GetAsyncEnumerableWithYieldAsync()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return await Task.FromResult(i);
        }
    }
}
