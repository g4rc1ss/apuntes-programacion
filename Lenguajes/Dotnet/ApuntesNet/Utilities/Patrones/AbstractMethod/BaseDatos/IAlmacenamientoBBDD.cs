namespace AbstractMethod.BaseDatos;

internal interface IAlmacenamientoBBDD
{
    void Guardar<T>(T entityDatabase);
}
