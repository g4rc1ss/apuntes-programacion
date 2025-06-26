using BenchmarkDotNet.Attributes;
using YieldBenchmark.Fakes;

namespace YieldBenchmark.Benchmarks;

[MemoryDiagnoser]
public class YieldVsList
{
    public YieldVsList() { }

    [Benchmark]
    public void ExpensiveObjectsWithList()
    {
        FakerYieldVsList.WithBuffer();
    }

    [Benchmark]
    public void ExpensiveObjectsWithYield()
    {
        IEnumerable<int>? response = FakerYieldVsList.WithYield();

        // Leemos el yield puesto que es una ejecucion diferida
        foreach (int item in response)
        {
            ;
        }
    }
}
