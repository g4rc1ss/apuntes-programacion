using Microsoft.Extensions.DependencyInjection;
using SqlServerEfCore;
using SqlServerEfCore.Database.Entities;
using SqlServerEfCore.Repository;

IServiceProvider? serviceProvider = Helper.CreateDependencyInjection();

InsertData? insertService = serviceProvider.GetRequiredService<InsertData>();
await insertService.InsertDataAsync();

UpdateData? updateService = serviceProvider.GetRequiredService<UpdateData>();
await updateService.UpdateDataAsync();

SelectData? selectService = serviceProvider.GetRequiredService<SelectData>();
List<Usuario>? allUsers = await selectService.SelectDataAsync();

DeleteData? deleteService = serviceProvider.GetRequiredService<DeleteData>();
await deleteService.DeleteDataAsync();

foreach (Usuario? user in allUsers)
{
    Console.WriteLine(
        $"Nombre {user.Nombre} - Edad {user.Edad} - Pueblo {user.PuebloNavigation.Nombre}"
    );
}

Console.WriteLine("\n Pulsa una tecla para finalizar");
Console.ReadKey();
