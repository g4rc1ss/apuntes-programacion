using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection? services = new();

services.AddTransient<IServicioInyectado, ServicioInyectado>();

ServiceProvider? serviceProvider = services.BuildServiceProvider();

IServicioInyectado? servicio = serviceProvider.GetRequiredService<IServicioInyectado>();

await servicio.ExecuteAsync();
