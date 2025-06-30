namespace ParallelBenchmark.Fakes;

internal static class FakerThreadVsAsync
{
    private const int DELAY = 100;

    internal static Task ExecuteTask()
    {
        return Task.Delay(DELAY);
    }

    internal static Task ExecuteTaskBlocking()
    {
#pragma warning disable CA1849
        ExecuteTask().Wait();
#pragma warning restore CA1849
        return Task.CompletedTask;
    }
}
