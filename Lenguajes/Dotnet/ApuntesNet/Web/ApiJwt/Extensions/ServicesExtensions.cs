using Microsoft.EntityFrameworkCore;

namespace ApiJwt.Extensions;

public static class ServicesExtensions
{
    public static void AddDatabase(this IHostApplicationBuilder builder)
    {
        string? connectionString = builder.Configuration.GetConnectionString(
            nameof(DatabaseDbContext)
        );
        ArgumentNullException.ThrowIfNull(connectionString);

        builder.Services.AddDbContextPool<DatabaseDbContext>(builder =>
            builder.UseNpgsql(connectionString)
        );

        builder.Services.AddDbContextFactory<DatabaseDbContext>(builder =>
            builder.UseNpgsql(connectionString)
        );
    }
}
