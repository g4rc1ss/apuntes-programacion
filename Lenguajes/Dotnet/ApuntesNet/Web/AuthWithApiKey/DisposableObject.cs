namespace AuthWithApiKey;

public class DisposableObject : IDisposable
{
    public readonly HttpClient client = new();

    public void Dispose()
    {
        Console.WriteLine("Ejecutando el dispose");
        client.Dispose();
    }
}
