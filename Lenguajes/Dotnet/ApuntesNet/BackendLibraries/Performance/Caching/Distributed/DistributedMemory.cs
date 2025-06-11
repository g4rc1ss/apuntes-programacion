using System.Text.Json;
using Caching.ObjCaching;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace Caching.Distributed;

internal class DistributedMemory
{
    private readonly IDistributedCache _distributedCache;

    public DistributedMemory()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddDistributedMemoryCache();
        ServiceProvider? serviceProvider = services.BuildServiceProvider();
        _distributedCache = serviceProvider.GetRequiredService<IDistributedCache>();
    }

    public async Task DistributedMemoryWithDIAsync()
    {
        string? listaSerializada = JsonSerializer.Serialize(ObjectsToCaching.listToCache);

        await _distributedCache.SetStringAsync(ObjectsToCaching.cacheKey, listaSerializada);

        string? listaSerializadaRecuperada = await _distributedCache.GetStringAsync(
            ObjectsToCaching.cacheKey
        );
        IEnumerable<int>? listaCacheRecuperada = JsonSerializer.Deserialize<IEnumerable<int>>(
            listaSerializadaRecuperada
        )!;

        if (listaSerializadaRecuperada.Count() > 0)
        {
            listaCacheRecuperada
                .Select(x =>
                {
                    Console.WriteLine(x);
                    return x;
                })
                .ToList();
        }
        _distributedCache.Remove(ObjectsToCaching.cacheKey);
    }
}
