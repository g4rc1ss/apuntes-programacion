using System.Data.Common;
using DbConnectionExtensions.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace DbConnectionExtensions.DependencyInjection;

/// <summary>
///
/// </summary>
public static class DbConnectionFactoryDI
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connection"></param>
    /// <returns></returns>
    public static IServiceCollection AddDbConnectionFactory(
        this IServiceCollection services,
        Func<DbConnection> connection
    )
    {
        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>(
            serviceProvider => new DbConnectionFactory(connection)
        );

        return services;
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TDatabaseNameContext"></typeparam>
    /// <param name="services"></param>
    /// <param name="connection"></param>
    /// <returns></returns>
    public static IServiceCollection AddDbConnectionFactory<TDatabaseNameContext>(
        this IServiceCollection services,
        Func<DbConnection> connection
    )
        where TDatabaseNameContext : class
    {
        services.AddSingleton<
            IDbConnectionFactory<TDatabaseNameContext>,
            DbConnectionFactory<TDatabaseNameContext>
        >(serviceProvider => new DbConnectionFactory<TDatabaseNameContext>(connection));

        return services;
    }
}
