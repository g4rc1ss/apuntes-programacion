using MongoDatabase.Document;
using MongoDB.Bson;

namespace MongoDatabase.Queries;

internal static class InsertData
{
    public static async Task Insert()
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
        await Helper
            .GetConnectionDatabase.GetCollection<Persona>("persona")
            .InsertManyAsync(persona);
        Console.WriteLine("Datos Insertados");
    }
}
