using BenchmarkDotNet.Attributes;

namespace DatabaseLibrariesBenchmark.Benchmarks;

[MemoryDiagnoser]
public partial class DatabaseFrameworksPerformance
{
    public int id;

    public void Step()
    {
        id++;
        if (id > 10000)
        {
            id = 1;
        }
    }
}
