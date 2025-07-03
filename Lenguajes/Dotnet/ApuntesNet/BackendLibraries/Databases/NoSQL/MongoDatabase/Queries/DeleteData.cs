using MongoDatabase.Document;
using MongoDB.Driver;

namespace MongoDatabase.Queries;

internal static class DeleteData
{
    public static async Task DeleteAsync()
    {
        FilterDefinition<Persona>? filter = Builders<Persona>.Filter.Eq(x => x.Name, "asier");

        using IMongoClient mongoClient = Helper.GetMongoClient;

        DeleteResult? resultadoDelete = await mongoClient
            .GetDatabase()
            .GetCollection<Persona>("persona")
            .DeleteOneAsync(filter);

        Console.WriteLine($"Datos borrados: {resultadoDelete.DeletedCount}");
    }
}
