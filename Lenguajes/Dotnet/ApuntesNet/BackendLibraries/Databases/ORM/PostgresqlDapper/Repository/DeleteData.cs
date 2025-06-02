using System.Data;
using Dapper;
using PostgresqlDapper.Entities;

namespace PostgresqlDapper.Repository;

internal class DeleteData(IDbConnection dbConnection)
{
    internal async Task DeleteDataQueryAsync()
    {
        string? deleteUsuario =
            @$"
DELETE FROM {nameof(Usuario)} 
WHERE Id = @idUsuario";
        int nChangesUsuario = await dbConnection.ExecuteAsync(
            deleteUsuario.ToString(),
            new { idUsuario = 2 }
        );

        Console.WriteLine($"Borrado {nChangesUsuario} registros");
    }
}
