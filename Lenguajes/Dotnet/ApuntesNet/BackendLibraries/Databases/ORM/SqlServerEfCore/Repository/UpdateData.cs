using SqlServerEfCore.Database;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Repository;

public class UpdateData(EntityFrameworkSqlServerContext frameworkSqlServerContext)
{
    internal Task<int> UpdateDataAsync()
    {
        int idPueblo = 1;

        Usuario? usuario = (
            from user in frameworkSqlServerContext.Usuarios
            where user.PuebloNavigation.Id == idPueblo
            select user
        ).Single();

        usuario.Nombre = "cnifvbdilcbsuyvrg";

        frameworkSqlServerContext.Update(usuario);
        return frameworkSqlServerContext.SaveChangesAsync();
    }
}
