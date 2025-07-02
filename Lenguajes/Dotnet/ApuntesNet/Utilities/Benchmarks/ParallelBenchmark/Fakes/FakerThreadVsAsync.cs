using System.Diagnostics.CodeAnalysis;

namespace ParallelBenchmark.Fakes;

[SuppressMessage(
    "Performance",
    "CA1849:Llame a métodos asincrónicos cuando esté en un método asincrónico"
)]
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
