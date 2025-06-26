using HostedService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHostBuilder? builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services =>
{
    services.AddSingleton<IServicioInyectado, ServicioInyectado>();
    services.AddHostedService<BackgroundServiceTask>();
    services.AddHostedService<OtroHostedService>();
});

IHost? app = builder.Build();

await app.RunAsync();
