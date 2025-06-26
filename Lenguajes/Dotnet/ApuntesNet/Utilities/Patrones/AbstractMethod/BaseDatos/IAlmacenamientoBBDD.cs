namespace AbstractMethod.BaseDatos;

internal interface IAlmacenamientoBbdd
{
    void Guardar<T>(T entityDatabase);
}
