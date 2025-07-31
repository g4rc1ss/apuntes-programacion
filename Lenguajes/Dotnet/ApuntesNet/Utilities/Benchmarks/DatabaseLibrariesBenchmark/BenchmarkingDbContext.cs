using DatabaseLibrariesBenchmark.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrariesBenchmark;

internal class BenchmarkingDbContext : DbContext
{
    public DbSet<WeatherForecast> WeatherForecast { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        MySqlServerVersion? version = new(MySqlServerVersion.LatestSupportedServerVersion);
        optionsBuilder.UseMySql(Helper.CONNECTION_STRING, version);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>().ToTable("WeatherForecast");
        base.OnModelCreating(modelBuilder);
    }
}
