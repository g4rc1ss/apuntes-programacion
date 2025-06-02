using System.Data;
using Dapper;
using PostgresqlDapper.Entities;

namespace PostgresqlDapper.Repository;

internal class UpdateData(IDbConnection dbConnection)
{
    internal async Task UpdateDataQueryAsync()
    {
        string? updatePueblo =
            @$"
UPDATE {nameof(Pueblo)}
SET nombre = 'Bilbao'
WHERE Id = @idPueblo;

UPDATE {nameof(Usuario)}
SET nombre = 'Ramon'
WHERE Id = @idUsuario
";

        int nChanges = await dbConnection.ExecuteAsync(
            updatePueblo,
            new { idPueblo = 1, idUsuario = 4 }
        );

        Console.WriteLine($"Actualizado {nChanges} registros");
    }
}
