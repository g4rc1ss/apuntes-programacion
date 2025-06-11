namespace HttpClientVsHttpClientFactory;

public class PruebaHttpClient(HttpClient client)
{
    public async Task ExecutePrueba(string endpoint)
    {
        await client.GetAsync(endpoint);
    }
}
