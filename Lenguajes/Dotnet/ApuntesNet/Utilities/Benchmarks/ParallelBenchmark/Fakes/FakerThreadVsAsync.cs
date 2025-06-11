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
        ExecuteTask().Wait();
        return Task.CompletedTask;
    }
}
