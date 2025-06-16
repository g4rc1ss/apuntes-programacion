namespace Flyweight;

internal static class FlyweightCache
{
    private static readonly Dictionary<string, object> _cache = [];

    public static bool TryGetValue(string id, out object value)
    {
        return _cache.TryGetValue(id, out value);
    }

    public static bool TryGetValue<T>(string id, out T value)
    {
        bool hasValue = _cache.TryGetValue(id, out object? objectValue);
        value = (T)objectValue;
        return hasValue;
    }

    public static void SetValue(string id, object value)
    {
        _cache.Add(id, value);
    }
}
