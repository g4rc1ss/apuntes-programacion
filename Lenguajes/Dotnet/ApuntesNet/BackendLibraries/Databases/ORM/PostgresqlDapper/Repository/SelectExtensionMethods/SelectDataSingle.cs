using Dapper;
using PostgresqlDapper.Entities;

namespace PostgresqlDapper.Repository.SelectExtensionMethods;

internal static class SelectDataSingle
{
    internal static async Task SelectDataSingleAsync(this SelectData select)
    {
        string? sqlPueblo =
            @$"
SELECT Id as {nameof(Pueblo.IdPueblo)}
    ,Nombre as {nameof(Pueblo.NombrePueblo)}
FROM {nameof(Pueblo)}
WHERE Id = @IdPueblo
";
        var parameters = new { IdPueblo = 2 };

        Pueblo? respuestaPueblo = await select.dbConnection.QuerySingleAsync<Pueblo>(
            sqlPueblo,
            parameters
        );
    }
}
