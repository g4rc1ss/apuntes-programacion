namespace FactoryMethod;

internal interface IAlmacenamiento
{
    bool Guardar<T>(T entity);
    Task<bool> GuardarAsync<T>(T entity);
}
