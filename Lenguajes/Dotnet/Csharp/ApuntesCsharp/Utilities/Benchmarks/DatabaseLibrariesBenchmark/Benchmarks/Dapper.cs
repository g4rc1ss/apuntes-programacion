using System.Data;
using BenchmarkDotNet.Attributes;
using Dapper;
using DatabaseLibrariesBenchmark.Entities;

namespace DatabaseLibrariesBenchmark.Benchmarks;

public partial class DatabaseFrameworksPerformance
{
    private readonly IDbConnection _dbConnection;
    private readonly BenchmarkingDbContext _benchmarkContext;

    public DatabaseFrameworksPerformance()
    {
        _dbConnection = Helper.GetDbConnection;
        _benchmarkContext = Helper.GetDbContext;
    }

    [Benchmark(Description = "Dapper single")]
    public void DapperSelectSingleQuery()
    {
        Step();
        string? sql =
            @"
SELECT * 
FROM BenchmarkingDatabases.WeatherForecast
Where Id = @id
LIMIT 0, 1
";

        WeatherForecast? result = _dbConnection.QuerySingle<WeatherForecast>(sql, new { Id = id });
    }
}
