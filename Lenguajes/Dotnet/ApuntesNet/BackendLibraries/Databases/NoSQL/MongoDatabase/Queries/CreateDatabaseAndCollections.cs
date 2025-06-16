using MongoDB.Driver;

namespace MongoDatabase.Queries;

internal class CreateDatabaseAndCollections
{
    internal static async Task CreateCollectionAsync()
    {
        if (
            (
                await (await Helper.GetConnectionDatabase.ListCollectionNamesAsync()).ToListAsync()
            ).FirstOrDefault(x => x == "persona") == null
        )
        {
            await Helper.GetConnectionDatabase.CreateCollectionAsync("persona");
        }
    }
}
