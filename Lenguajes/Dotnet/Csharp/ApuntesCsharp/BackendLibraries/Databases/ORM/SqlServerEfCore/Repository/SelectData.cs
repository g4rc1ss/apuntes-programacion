using Microsoft.EntityFrameworkCore;
using SqlServerEfCore.Database;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Repository;

internal class SelectData(EntityFrameworkSqlServerContext frameworkSqlServerContext)
{
    public async Task<List<Usuario>> SelectDataAsync()
    {
        Pueblo[]? pueblos = await frameworkSqlServerContext.Pueblos.ToArrayAsync();
        Usuario[]? usuarios = await frameworkSqlServerContext.Usuarios.ToArrayAsync();
        Pueblo[]? pueblosInclude = await frameworkSqlServerContext
            .Pueblos.Include(x => x.Usuarios)
            .ToArrayAsync();
        Usuario[]? usuariosInclude = await frameworkSqlServerContext
            .Usuarios.Include(x => x.PuebloNavigation)
            .ToArrayAsync();

        return await (
            from usuario in frameworkSqlServerContext.Usuarios
            join pueblo in frameworkSqlServerContext.Pueblos on usuario.PuebloId equals pueblo.Id
            select usuario
        ).ToListAsync();
    }
}
