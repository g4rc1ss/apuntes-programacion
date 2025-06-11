namespace AbstractMethod.BaseDatos;

internal class AlmacenamientoBBDD : IAlmacenamientoBBDD
{
    public void Guardar<T>(T entityDatabase)
    {
        Console.WriteLine(entityDatabase);
    }
}
