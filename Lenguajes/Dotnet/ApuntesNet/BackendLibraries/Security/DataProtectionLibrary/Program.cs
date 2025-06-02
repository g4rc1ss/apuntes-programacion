using DataProtectionLibrary;
using DataProtectionLibrary.Protections;
using Microsoft.Extensions.DependencyInjection;

IServiceProvider? serviceProvider = Helper.GetServiceProvider();

DataProtectionExample? dataProtect = serviceProvider.GetRequiredService<DataProtectionExample>();
dataProtect.ProtectingData();

Console.WriteLine("Pulsa una tecla para continuar...");
Console.Read();
