using MongoDB.Driver;

namespace MongoDatabase;

internal class Helper
{
    private static readonly string ConnectionString = "mongodb://root:123456@localhost:27017/";
    internal static IMongoClient GetMongoClient => new MongoClient(ConnectionString);

    internal static IMongoDatabase GetConnectionDatabase => GetMongoClient.GetDatabase("prueba");
}
