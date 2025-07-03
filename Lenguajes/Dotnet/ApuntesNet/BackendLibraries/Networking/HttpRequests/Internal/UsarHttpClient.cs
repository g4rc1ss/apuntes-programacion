using System.Net.Http.Json;

namespace HttpRequests.Internal;

internal class UsarHttpClient(IHttpClientFactory httpClientFactory) : IDisposable
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("clientePrueba");
    private bool _disposed;

    public Task<object> ExecuteHttpClientAsync()
    {
        return _httpClient.GetFromJsonAsync<object>("pokemon/lucario");
    }

    public virtual void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;

        _httpClient?.Dispose();
    }

    protected virtual void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
    }
}
