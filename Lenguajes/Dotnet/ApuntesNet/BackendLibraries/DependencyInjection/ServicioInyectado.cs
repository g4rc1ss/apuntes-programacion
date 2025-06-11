namespace DependencyInjection;

internal interface IServicioInyectado
{
    Task<bool> ExecuteAsync(CancellationToken cancellationToken = default);
}

public class ServicioInyectado : IServicioInyectado
{
    public Task<bool> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Ejecutando el Servicio Inyectado");

        return Task.FromResult(true);
    }
}
