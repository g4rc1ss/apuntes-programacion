namespace HttpClientVsHttpClientFactory;

public class PruebaHttpClientFactory(IHttpClientFactory httpClientFactory)
{
    public async Task ExecutePruebaAsync(string endpoint)
    {
        using HttpClient? client = httpClientFactory.CreateClient();

        await client.GetAsync(endpoint);
    }
}
