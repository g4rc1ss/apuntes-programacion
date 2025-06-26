using System.Data;
using MySqlConnector;

namespace DatabaseLibrariesBenchmark;

internal class Helper
{
    public static readonly string connectionString =
        "Server=localhost;Database=BenchmarkingDatabases;Uid=root;Pwd=123456;";
    public static IDbConnection GetDbConnection => new MySqlConnection(connectionString);

    public static BenchmarkingDbContext GetDbContext => new();
}
