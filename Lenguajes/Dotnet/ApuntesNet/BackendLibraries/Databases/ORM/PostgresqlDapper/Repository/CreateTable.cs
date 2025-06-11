using System.Data;
using Dapper;

namespace PostgresqlDapper.Repository;

internal class CreateTable(IDbConnection dbConnection)
{
    public async Task CreateTableAsync()
    {
        string? createUsuario =
            @"CREATE TABLE Usuario(
                                        Id         SERIAL     NOT NULL,
                                        Nombre     TEXT    NOT NULL,
                                        IdPueblo   INT     NOT NULL,
                                        CONSTRAINT PK_Usuario PRIMARY KEY (Id),
                                        CONSTRAINT FK_pueblo FOREIGN KEY (IdPueblo)
                                        REFERENCES Pueblo(Id)
                                        ON DELETE CASCADE
                                        ON UPDATE CASCADE);";

        string? createPueblo =
            @"CREATE TABLE Pueblo(
                                        Id         SERIAL     NOT NULL,
                                        Nombre     TEXT    NOT NULL,
                                        CONSTRAINT PK_Pueblo PRIMARY KEY (Id))";

        await dbConnection.ExecuteAsync(createPueblo);
        await dbConnection.ExecuteAsync(createUsuario);
    }
}
