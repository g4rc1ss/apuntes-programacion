using System.Data;
using BenchmarkDotNet.Attributes;
using Dapper;
using DatabaseLibrariesBenchmark.Entities;

namespace DatabaseLibrariesBenchmark.Benchmarks;

[MemoryDiagnoser]
public class DapperBench
{
    private readonly IDbConnection _dbConnection = Helper.GetDbConnection;

    [Benchmark(Description = "Dapper single")]
    public async Task DapperSelectSingleQueryAsync()
    {
        string sql = """
            SELECT * 
            FROM WeatherForecast
            Where Id = @Id
            LIMIT 0, 1
            """;

        await _dbConnection.QuerySingleAsync<WeatherForecast>(sql, new { Id = 1 });
    }

    [Benchmark(Description = "Dapper Query")]
    public async Task DapperSelectAllQueryAsync()
    {
        string sql = """
            SELECT * 
            FROM WeatherForecast
            """;

        await _dbConnection.QueryAsync<WeatherForecast>(sql);
    }
}
