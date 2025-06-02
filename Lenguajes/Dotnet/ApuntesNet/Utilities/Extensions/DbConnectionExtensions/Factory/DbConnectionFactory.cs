using System.Data.Common;

namespace DbConnectionExtensions.Factory;

internal class DbConnectionFactory : IDbConnectionFactory
{
    private readonly Func<DbConnection> _connection;

    internal DbConnectionFactory(Func<DbConnection> connection)
    {
        _connection = connection;
    }

    public DbConnection CreateDbConnection()
    {
        return _connection();
    }
}

internal class DbConnectionFactory<TDatabaseNameContext>
    : DbConnectionFactory,
        IDbConnectionFactory<TDatabaseNameContext>
    where TDatabaseNameContext : class
{
    internal DbConnectionFactory(Func<DbConnection> connection)
        : base(connection) { }
}
