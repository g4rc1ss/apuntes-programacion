using System.Text.Json;
using Caching.ObjCaching;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace Caching.Distributed;

internal class DistributedRedis
{
    private readonly IDistributedCache _distributedCache;

    public DistributedRedis()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "localhost:6379,password=password123";
            options.InstanceName = "localhost";
        });

        using ServiceProvider? serviceProvider = services.BuildServiceProvider();
        _distributedCache = serviceProvider.GetRequiredService<IDistributedCache>();
    }

    public async Task DistributedRedisAsync()
    {
        string? listaSerializada = JsonSerializer.Serialize(ObjectsToCaching.listToCache);

        await _distributedCache.SetStringAsync(ObjectsToCaching.cacheKey, listaSerializada);

        string? listaSerializadaRecuperada = await _distributedCache.GetStringAsync(
            ObjectsToCaching.cacheKey
        );
        IEnumerable<int>? listaCacheRecuperada = JsonSerializer.Deserialize<IEnumerable<int>>(
            listaSerializadaRecuperada
        )!;

        if (listaSerializadaRecuperada.Any())
        {
            listaCacheRecuperada
                .Select(x =>
                {
                    Console.WriteLine(x);
                    return x;
                })
                .ToList();
        }
        await _distributedCache.RemoveAsync(ObjectsToCaching.cacheKey);
    }
}
