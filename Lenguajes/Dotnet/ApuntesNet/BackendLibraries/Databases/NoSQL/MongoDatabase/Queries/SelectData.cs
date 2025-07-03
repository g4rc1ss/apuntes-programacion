using MongoDatabase.Document;
using MongoDB.Driver;

namespace MongoDatabase.Queries;

internal static class SelectData
{
    public static async Task SelectAsync()
    {
        using IMongoClient mongoClient = Helper.GetMongoClient;

        using IAsyncCursor<Persona>? result = await mongoClient
            .GetDatabase()
            .GetCollection<Persona>("persona")
            .FindAsync(FilterDefinition<Persona>.Empty);
        List<Persona>? listaResultados = await result.ToListAsync();

        foreach (Persona? item in listaResultados)
        {
            Console.WriteLine(item.Name);
        }
    }
}
