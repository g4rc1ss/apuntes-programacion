namespace Caching.ObjCaching;

internal static class ObjectsToCaching
{
    internal static IEnumerable<int> listToCache = Enumerable.Range(0, 10).Select(x => x);
    internal static string cacheKey = "KeyIdentificadorCache";
}
