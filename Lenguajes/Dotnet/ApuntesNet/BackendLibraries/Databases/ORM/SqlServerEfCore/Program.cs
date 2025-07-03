using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlServerEfCore;
using SqlServerEfCore.Database.Entities;
using SqlServerEfCore.Repository;

IHost? host = Helper.CreateDependencyInjection();

InsertData? insertService = host.Services.GetRequiredService<InsertData>();
await insertService.InsertDataAsync();

UpdateData? updateService = host.Services.GetRequiredService<UpdateData>();
await updateService.UpdateDataAsync();

SelectData? selectService = host.Services.GetRequiredService<SelectData>();
List<Usuario>? allUsers = await selectService.SelectDataAsync();

DeleteData? deleteService = host.Services.GetRequiredService<DeleteData>();
await deleteService.DeleteDataAsync();

foreach (Usuario? user in allUsers)
{
    Console.WriteLine(
        $"Nombre {user.Nombre} - Edad {user.Edad} - Pueblo {user.PuebloNavigation.Nombre}"
    );
}

Console.WriteLine("\n Pulsa una tecla para finalizar");
Console.ReadKey();
