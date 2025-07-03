using MongoDatabase.Document;
using MongoDB.Driver;

namespace MongoDatabase.Queries;

internal static class UpdateData
{
    public static async Task UpdateAsync()
    {
        FilterDefinition<Persona>? filter = Builders<Persona>.Filter.Eq(x => x.Name, "asier");
        UpdateDefinition<Persona>? update = Builders<Persona>.Update.Set(
            x => x.Name,
            "asier updateado"
        );
        using IMongoClient mongoClient = Helper.GetMongoClient;

        UpdateResult? valorRespuesta = await mongoClient
            .GetDatabase()
            .GetCollection<Persona>("persona")
            .UpdateOneAsync(filter, update);

        Console.WriteLine($"Se han modificado {valorRespuesta.ModifiedCount}");
    }
}
