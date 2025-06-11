using MongoDatabase.Document;
using MongoDB.Driver;

namespace MongoDatabase.Queries;

internal static class DeleteData
{
    public static async Task Delete()
    {
        FilterDefinition<Persona>? filter = Builders<Persona>.Filter.Eq(x => x.Name, "asier");
        DeleteResult? resultadoDelete = await Helper
            .GetConnectionDatabase.GetCollection<Persona>("persona")
            .DeleteOneAsync(filter);

        Console.WriteLine($"Datos borrados: {resultadoDelete.DeletedCount}");
    }
}
