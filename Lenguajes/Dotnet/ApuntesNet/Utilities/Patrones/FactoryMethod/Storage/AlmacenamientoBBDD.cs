namespace FactoryMethod.Storage;

internal class AlmacenamientoBbdd : IAlmacenamiento
{
    public bool Guardar<T>(T entity)
    {
        Console.WriteLine($"Guardando datos de {entity} en base de datos");
        return true;
    }

    public Task<bool> GuardarAsync<T>(T entity)
    {
        Console.WriteLine($"Guardando datos de {entity} en base de datos");
        return Task.FromResult(true);
    }
}
