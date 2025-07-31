using BenchmarkDotNet.Attributes;
using DatabaseLibrariesBenchmark.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrariesBenchmark.Benchmarks;

[MemoryDiagnoser]
public class EntityFrameworkBench
{
    private readonly BenchmarkingDbContext _benchmarkContext = Helper.GetDbContext;

    private static Func<BenchmarkingDbContext, int, Task<WeatherForecast>> CompiledQuery =>
        EF.CompileAsyncQuery(
            (BenchmarkingDbContext context, int identity) =>
                context.WeatherForecast.Single(forecast => forecast.Id == identity)
        );

    [Benchmark(Description = "EF Core Single")]
    public async Task EntityFrameworkCoreSelectSingleQueryAsync()
    {
        WeatherForecast? result = await _benchmarkContext
            .WeatherForecast.AsTracking()
            .Where(x => x.Id == 2)
            .SingleAsync();
    }

    [Benchmark(Description = "EF Core Single no Tracking")]
    public async Task EntityFrameworkCoreSelectSingleNoTrackingQueryAsync()
    {
        WeatherForecast? result = await _benchmarkContext
            .WeatherForecast.AsNoTracking()
            .Where(x => x.Id == 2)
            .SingleAsync();
    }

    [Benchmark(Description = "EF Core All")]
    public async Task EntityFrameworkCoreSelectAllQueryAsync()
    {
        await _benchmarkContext.WeatherForecast.AsTracking().ToListAsync();
    }

    [Benchmark(Description = "EF Core All no Tracking")]
    public async Task EntityFrameworkCoreSelectAllNoTrackingQueryAsync()
    {
        await _benchmarkContext.WeatherForecast.AsNoTracking().ToListAsync();
    }

    [Benchmark(Description = "EF Core Single Compilada")]
    public async Task EntityFrameworkCoreSelectSingleCompiledQueryAsync()
    {
        WeatherForecast? result = await CompiledQuery(_benchmarkContext, 2);
    }
}
