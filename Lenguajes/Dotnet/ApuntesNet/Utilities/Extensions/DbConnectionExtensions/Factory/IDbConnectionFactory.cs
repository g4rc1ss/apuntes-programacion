using System.Data.Common;

namespace DbConnectionExtensions.Factory;

public interface IDbConnectionFactory
{
    DbConnection CreateDbConnection();
}

public interface IDbConnectionFactory<TDatabaseNameContext> : IDbConnectionFactory { }
