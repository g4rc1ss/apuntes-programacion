namespace HttpClientVsHttpClientFactory;

public class PruebaHttpClient(HttpClient client)
{
    public async Task ExecutePruebaAsync(string endpoint)
    {
        await client.GetAsync(endpoint);
    }
}
