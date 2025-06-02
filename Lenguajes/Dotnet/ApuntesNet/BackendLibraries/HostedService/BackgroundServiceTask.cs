using Microsoft.Extensions.Hosting;

namespace HostedService;

public class BackgroundServiceTask(IServicioInyectado servicioInyectado) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("Este es el metodo de Start");
            int counter = await servicioInyectado.ExecuteAsync(stoppingToken);
            Console.WriteLine(counter);
            await Task.Delay(1100, stoppingToken);
        }
    }
}
