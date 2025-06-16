using DatabaseLibrariesBenchmark.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrariesBenchmark;

internal class BenchmarkingDbContext : DbContext
{
    public DbSet<WeatherForecast>? WeatherForecast { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        MySqlServerVersion? version = new(MySqlServerVersion.LatestSupportedServerVersion);
        optionsBuilder.UseMySql(Helper.connectionString, version);
        base.OnConfiguring(optionsBuilder);
    }
}
