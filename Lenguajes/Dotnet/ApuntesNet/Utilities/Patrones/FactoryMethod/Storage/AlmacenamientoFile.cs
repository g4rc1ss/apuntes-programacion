namespace FactoryMethod.Storage;

internal class AlmacenamientoFile : IAlmacenamiento
{
    public bool Guardar<T>(T entity)
    {
        Console.WriteLine($"Guardando datos de {entity} en archivo");
        return true;
    }

    public Task<bool> GuardarAsync<T>(T entity)
    {
        Console.WriteLine($"Guardando datos de {entity} en archivo");
        return Task.FromResult(true);
    }
}
