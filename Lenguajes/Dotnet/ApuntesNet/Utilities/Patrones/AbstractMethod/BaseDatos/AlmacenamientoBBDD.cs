namespace AbstractMethod.BaseDatos;

internal class AlmacenamientoBbdd : IAlmacenamientoBbdd
{
    public void Guardar<T>(T entityDatabase)
    {
        Console.WriteLine(entityDatabase);
    }
}
