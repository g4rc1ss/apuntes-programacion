using Microsoft.EntityFrameworkCore;
using SqlServerEfCore.Database;

namespace MigrationsSqlServer;

internal class MigrationService(EntityFrameworkSqlServerContext context)
{
    public async Task MigrateApplicationAsync()
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.MigrateAsync();
    }

    public Task InitializeDatabase()
    {
        return Task.CompletedTask;
    }
}
