namespace HttpClientVsHttpClientFactory;

public class PruebaUsingHttpClient
{
    public async Task ExecutePruebaAsync(string endpoint)
    {
        using HttpClient? client = new();

        await client.GetAsync(endpoint);
    }
}
