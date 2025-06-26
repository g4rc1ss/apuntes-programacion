namespace AbstractMethod.Api;

internal class AlmacenamientoApi : IAlmacenamientoApi
{
    public string Guardar(string objetoEnviado)
    {
        Console.WriteLine(objetoEnviado);
        return "cosas nazis";
    }
}
