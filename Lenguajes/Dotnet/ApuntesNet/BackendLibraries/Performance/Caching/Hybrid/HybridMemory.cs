using Caching.ObjCaching;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.DependencyInjection;

namespace Caching.Hybrid;

internal class HybridMemory
{
    private readonly HybridCache _hybridCache;

    public HybridMemory()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddHybridCache();
        ServiceProvider? serviceProvider = services.BuildServiceProvider();
        _hybridCache = serviceProvider.GetRequiredService<HybridCache>();
    }

    public async Task HybridMemoryWithDiAsync()
    {
        await _hybridCache.SetAsync(ObjectsToCaching.cacheKey, ObjectsToCaching.listToCache);

        IEnumerable<int>? listaCacheRecuperada = await _hybridCache.GetOrCreateAsync(
            ObjectsToCaching.cacheKey,
            async x => await Task.FromResult(Enumerable.Empty<int>())
        );

        listaCacheRecuperada.Select(x =>
        {
            Console.WriteLine(x);
            return x;
        }).ToList();

        await _hybridCache.RemoveAsync(ObjectsToCaching.cacheKey);
    }
}