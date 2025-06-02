using Microsoft.EntityFrameworkCore;
using SqlServerEfCore.Database;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Repository;

internal class DeleteData(EntityFrameworkSqlServerContext frameworkSqlServerContext)
{
    internal async Task<int> DeleteDataAsync()
    {
        List<Usuario>? usuarios = await (
            from user in frameworkSqlServerContext.Usuarios
            where user.Id == 1
            select user
        ).ToListAsync();
        frameworkSqlServerContext.RemoveRange(usuarios);
        return await frameworkSqlServerContext.SaveChangesAsync();
    }
}
