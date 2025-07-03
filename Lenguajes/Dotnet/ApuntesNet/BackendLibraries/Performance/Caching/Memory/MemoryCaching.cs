using Caching.ObjCaching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Caching.Memory;

internal class MemoryCaching : IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private bool _disposed;

    public MemoryCaching()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddMemoryCache();
        _serviceProvider = services.BuildServiceProvider();
    }

    public void MemoryCacheWithDi()
    {
        IMemoryCache? memoryCache = _serviceProvider.GetRequiredService<IMemoryCache>();

        TimeSpan timeStart = DateTime.Now.TimeOfDay;
        Console.WriteLine($"Obtenemos la lista {timeStart}");
        memoryCache.Set(
            ObjectsToCaching.cacheKey,
            ObjectsToCaching.listToCache,
            TimeSpan.FromMinutes(1)
        );

        Console.WriteLine($"Obtenemos la lista {DateTime.Now.TimeOfDay}");

        if (
            memoryCache.TryGetValue<IEnumerable<int>>(
                ObjectsToCaching.cacheKey,
                out IEnumerable<int>? listaCacheRecuperada
            )
        )
        {
            listaCacheRecuperada
                .Select(x =>
                {
                    Console.WriteLine(x);
                    return x;
                })
                .ToList();
        }

        memoryCache.Remove(ObjectsToCaching.cacheKey);
    }

    public virtual void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;

        (_serviceProvider as IDisposable)?.Dispose();
    }

    protected virtual void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(GetType().FullName);
        }
    }
}
