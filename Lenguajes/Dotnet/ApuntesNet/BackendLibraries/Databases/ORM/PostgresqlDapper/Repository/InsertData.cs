using System.Data;
using Dapper;
using PostgresqlDapper.Entities;

namespace PostgresqlDapper.Repository;

internal class InsertData(IDbConnection dbConnection)
{
    internal async Task InsertDataQueryAsync()
    {
        string? inserts =
            @$"
INSERT INTO {nameof(Pueblo)} (Nombre)
VALUES (@NombrePueblo);

INSERT INTO {nameof(Usuario)} (Nombre, IdPueblo)
VALUES (@NombreUsuario, currval(pg_get_serial_sequence('pueblo', 'id')));
";
        var parametros = Enumerable
            .Range(0, 100)
            .Select(i => new { NombrePueblo = "Albacete", NombreUsuario = "nombre de usuario" })
            .ToList();

        int nChanges = await dbConnection.ExecuteAsync(inserts, parametros);

        Console.WriteLine($"Agregado {nChanges} registros");
    }
}
