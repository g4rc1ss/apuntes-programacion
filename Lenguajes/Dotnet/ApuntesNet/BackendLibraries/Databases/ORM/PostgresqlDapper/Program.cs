using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PostgresqlDapper;
using PostgresqlDapper.Repository;
using PostgresqlDapper.Repository.SelectExtensionMethods;

IHost? host = Helper.CreateDependencyInjection();

CreateTable? createTable = host.Services.GetRequiredService<CreateTable>();
await createTable.CreateTableAsync();

InsertData? insertData = host.Services.GetRequiredService<InsertData>();
await insertData.InsertDataQueryAsync();

UpdateData? updateData = host.Services.GetRequiredService<UpdateData>();

//await updateData.UpdateDataQueryAsync();

SelectData? selectData = host.Services.GetRequiredService<SelectData>();
await selectData.SelectDataQueryAsync();
await selectData.SelectDataSingleAsync();
await selectData.SelectDataMultipleQueryAsync();
await selectData.SelectDataMappingComplexObjectsAsync();

DeleteData? deleteData = host.Services.GetRequiredService<DeleteData>();
await deleteData.DeleteDataQueryAsync();

Console.WriteLine("\n Pulsa una tecla para finalizar");
Console.ReadKey();
