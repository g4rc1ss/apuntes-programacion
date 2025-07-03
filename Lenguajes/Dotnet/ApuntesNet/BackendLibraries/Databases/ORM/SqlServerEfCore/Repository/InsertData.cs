using Microsoft.EntityFrameworkCore;
using SqlServerEfCore.Database;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Repository;

public class InsertData(
    IDbContextFactory<EntityFrameworkSqlServerContext> frameworkSqlServerContext
)
{
    internal async Task<int> InsertDataAsync()
    {
        using EntityFrameworkSqlServerContext dbContext =
            frameworkSqlServerContext.CreateDbContext();
        Usuario? usuarioAgregar = new()
        {
            Nombre = "Nombre del usuario",
            Edad = 10,
            FechaHoy = DateTime.Now,
            PuebloId = 20,
            PuebloNavigation = new Pueblo { Nombre = "Soria" },
        };

        dbContext.Usuarios.Add(usuarioAgregar);
        return await dbContext.SaveChangesAsync();
    }
}
