using System.Net.Http.Json;

namespace HttpRequests.Internal;

internal class UsarHttpClient(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("clientePrueba");

    public Task<object> ExecuteHttpClientAsync()
    {
        return _httpClient.GetFromJsonAsync<object>("pokemon/lucario");
    }
}
