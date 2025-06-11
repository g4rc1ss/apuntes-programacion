using System.Data;
using MySqlConnector;

namespace DatabaseLibrariesBenchmark;

internal class Helper
{
    public static readonly string ConnectionString =
        "Server=localhost;Database=BenchmarkingDatabases;Uid=root;Pwd=123456;";
    public static IDbConnection GetDbConnection => new MySqlConnection(ConnectionString);

    public static BenchmarkingDbContext GetDbContext => new();
}
