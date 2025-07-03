using MongoDB.Driver;

namespace MongoDatabase.Queries;

internal class CreateDatabaseAndCollections
{
    internal static async Task CreateCollectionAsync()
    {
        using IMongoClient mongoClient = Helper.GetMongoClient;
        using IAsyncCursor<string>? collectionNames = await mongoClient
            .GetDatabase()
            .ListCollectionNamesAsync();

        if ((await collectionNames.ToListAsync()).FirstOrDefault(x => x == "persona") == null)
        {
            await mongoClient.GetDatabase().CreateCollectionAsync("persona");
        }
    }
}
