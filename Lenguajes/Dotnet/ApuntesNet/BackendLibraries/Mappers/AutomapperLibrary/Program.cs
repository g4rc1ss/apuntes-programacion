using AutomapperLibrary;
using Microsoft.Extensions.DependencyInjection;

IServiceProvider? serviceProvider = Helper.GetServiceProvider();

AutoMappingClasses? autoMapping = serviceProvider.GetRequiredService<AutoMappingClasses>();
autoMapping.Mapping();

Console.WriteLine("Pulsa una tecla para terminar...");
Console.Read();
