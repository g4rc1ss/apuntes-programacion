using Microsoft.Extensions.DependencyInjection;
using PostgresqlDapper;
using PostgresqlDapper.Repository;
using PostgresqlDapper.Repository.SelectExtensionMethods;

IServiceProvider? serviceProvider = Helper.CreateDependencyInjection();

CreateTable? createTable = serviceProvider.GetRequiredService<CreateTable>();
await createTable.CreateTableAsync();

InsertData? insertData = serviceProvider.GetRequiredService<InsertData>();
await insertData.InsertDataQueryAsync();

UpdateData? updateData = serviceProvider.GetRequiredService<UpdateData>();

//await updateData.UpdateDataQueryAsync();

SelectData? selectData = serviceProvider.GetRequiredService<SelectData>();
await selectData.SelectDataQueryAsync();
await selectData.SelectDataSingleAsync();
await selectData.SelectDataMultipleQueryAsync();
await selectData.SelectDataMappingComplexObjectsAsync();

DeleteData? deleteData = serviceProvider.GetRequiredService<DeleteData>();
await deleteData.DeleteDataQueryAsync();

Console.WriteLine("\n Pulsa una tecla para finalizar");
Console.ReadKey();
