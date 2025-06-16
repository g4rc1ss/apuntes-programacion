using MongoDatabase.Queries;

await CreateDatabaseAndCollections.CreateCollectionAsync();
await InsertData.InsertAsync();
await UpdateData.UpdateAsync();
await DeleteData.DeleteAsync();
await SelectData.SelectAsync();

Console.WriteLine("Pulsa una tecla para terminar...");
Console.ReadKey();
