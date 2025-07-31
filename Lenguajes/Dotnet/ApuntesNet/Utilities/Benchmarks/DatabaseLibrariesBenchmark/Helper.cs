using System.Data;
using MySqlConnector;

namespace DatabaseLibrariesBenchmark;

internal class Helper
{
    public const string CONNECTION_STRING =
        "Server=localhost;Database=BenchmarkingDatabases;Uid=root;Pwd=123456;";
    public static IDbConnection GetDbConnection => new MySqlConnection(CONNECTION_STRING);
    public static BenchmarkingDbContext GetDbContext => new();
}
