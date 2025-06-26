using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlServerEfCore.Database;
using SqlServerEfCore.Repository;

namespace SqlServerEfCore;

internal class Helper
{
    public static IServiceProvider CreateDependencyInjection()
    {
        IHostBuilder? builder = Host.CreateDefaultBuilder();
        builder.ConfigureAppConfiguration(config => { });

        builder.ConfigureServices(
            (hostContext, services) =>
            {
                string? connectionString = hostContext.Configuration.GetConnectionString(
                    nameof(EntityFrameworkSqlServerContext)
                );
                services.AddDbContextPool<EntityFrameworkSqlServerContext>(dbContextBuilder =>
                    dbContextBuilder
                        .UseSqlServer(connectionString)
                        .AddInterceptors(new SoftDeleteInterceptor())
                );

                services.AddPooledDbContextFactory<EntityFrameworkSqlServerContext>(
                    dbContextBuilder =>
                        dbContextBuilder
                            .UseSqlServer(connectionString)
                            .AddInterceptors(new SoftDeleteInterceptor())
                );

                services.AddTransient<SelectData>();
                services.AddTransient<InsertData>();
                services.AddTransient<UpdateData>();
                services.AddTransient<DeleteData>();
            }
        );

        return builder.Build().Services;
    }
}
