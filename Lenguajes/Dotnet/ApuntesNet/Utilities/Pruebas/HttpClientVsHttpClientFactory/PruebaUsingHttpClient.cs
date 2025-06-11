namespace HttpClientVsHttpClientFactory;

public class PruebaUsingHttpClient
{
    public async Task ExecutePrueba(string endpoint)
    {
        using HttpClient? client = new();

        await client.GetAsync(endpoint);
    }
}
