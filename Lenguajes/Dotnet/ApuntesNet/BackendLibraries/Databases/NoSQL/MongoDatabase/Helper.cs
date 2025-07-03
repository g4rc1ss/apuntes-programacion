using MongoDB.Driver;

namespace MongoDatabase;

internal static class Helper
{
    private static readonly string _connectionString = "mongodb://root:123456@localhost:27017/";
    internal static IMongoClient GetMongoClient => new MongoClient(_connectionString);

    internal static IMongoDatabase GetDatabase(this IMongoClient mongoClient)
    {
        return mongoClient.GetDatabase("prueba");
    }
}
