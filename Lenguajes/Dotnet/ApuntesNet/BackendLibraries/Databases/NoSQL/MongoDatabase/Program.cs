using MongoDatabase.Queries;

await CreateDatabaseAndCollections.CreateCollection();
await InsertData.Insert();
await UpdateData.Update();
await DeleteData.Delete();
await SelectData.Select();

Console.WriteLine("Pulsa una tecla para terminar...");
Console.ReadKey();
