namespace HostedService;

public interface IServicioInyectado
{
    Task<int> ExecuteAsync(CancellationToken cancellationToken = default);
}

public class ServicioInyectado : IServicioInyectado
{
    public int counter = 0;

    public Task<int> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Ejecutando el Servicio Inyectado");
        counter++;
        return Task.FromResult(counter);
    }
}
