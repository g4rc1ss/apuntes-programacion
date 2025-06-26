using BenchmarkDotNet.Attributes;
using DatabaseLibrariesBenchmark.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrariesBenchmark.Benchmarks;

public partial class DatabaseFrameworksPerformance
{
    private static Func<BenchmarkingDbContext, int, WeatherForecast> CompiledQuery =>
        EF.CompileQuery(
            (BenchmarkingDbContext context, int identity) =>
                context.WeatherForecast.Where(x => x.Id == identity).Single()
        );

    [Benchmark(Description = "EF Core Single")]
    public void EntityFrameworkCoreSelectSingleQuery()
    {
        Step();
        WeatherForecast? result = _benchmarkContext
            .WeatherForecast.Where(x => x.Id == id)
            .Take(1)
            .Single();
    }

    [Benchmark(Description = "EF Core Single no Tranking")]
    public void EntityFrameworkCoreSelectSingleNoTrackingQuery()
    {
        Step();
        WeatherForecast? result = _benchmarkContext
            .WeatherForecast.Where(x => x.Id == id)
            .AsNoTracking()
            .Single();
    }

    [Benchmark(Description = "EF Core Single Compilada")]
    public void EntityFrameworkCoreSelectSingleCompiledQuery()
    {
        Step();
        WeatherForecast? result = CompiledQuery(_benchmarkContext, id);
    }
}
