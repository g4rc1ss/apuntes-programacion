using MongoDatabase.Document;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDatabase.Queries;

internal static class InsertData
{
    public static async Task InsertAsync()
    {
        List<Persona>? persona =
        [
            new()
            {
                Id = new ObjectId(),
                Name = "asier",
                SubName = "garcia",
                FechaNacimiento = new DateTime(1997, 08, 27),
            },
            new()
            {
                Id = new ObjectId(),
                Name = "asier",
                SubName = "garcia",
                FechaNacimiento = new DateTime(1997, 08, 27),
            },
            new()
            {
                Id = new ObjectId(),
                Name = "asier",
                SubName = "garcia",
                FechaNacimiento = new DateTime(1997, 08, 27),
            },
            new()
            {
                Id = new ObjectId(),
                Name = "asier",
                SubName = "garcia",
                FechaNacimiento = new DateTime(1997, 08, 27),
            },
            new()
            {
                Id = new ObjectId(),
                Name = "asier",
                SubName = "garcia",
                FechaNacimiento = new DateTime(1997, 08, 27),
            },
        ];

        using IMongoClient mongoClient = Helper.GetMongoClient;

        await mongoClient.GetDatabase().GetCollection<Persona>("persona").InsertManyAsync(persona);
        Console.WriteLine("Datos Insertados");
    }
}
