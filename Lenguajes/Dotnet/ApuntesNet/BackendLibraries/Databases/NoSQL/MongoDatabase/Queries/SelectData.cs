using MongoDatabase.Document;
using MongoDB.Driver;

namespace MongoDatabase.Queries;

internal static class SelectData
{
    public static async Task Select()
    {
        IAsyncCursor<Persona>? result = await Helper
            .GetConnectionDatabase.GetCollection<Persona>("persona")
            .FindAsync(FilterDefinition<Persona>.Empty);
        List<Persona>? listaResultados = await result.ToListAsync();

        foreach (Persona? item in listaResultados)
        {
            Console.WriteLine(item.Name);
        }
    }
}
