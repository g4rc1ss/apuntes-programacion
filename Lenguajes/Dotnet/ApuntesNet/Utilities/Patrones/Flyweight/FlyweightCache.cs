namespace Flyweight;

internal static class FlyweightCache
{
    private static readonly Dictionary<string, object> Cache = [];

    public static bool TryGetValue(string id, out object value)
    {
        return Cache.TryGetValue(id, out value);
    }

    public static bool TryGetValue<T>(string id, out T value)
    {
        bool hasValue = Cache.TryGetValue(id, out object? objectValue);
        value = (T)objectValue;
        return hasValue;
    }

    public static void SetValue(string id, object value)
    {
        Cache.Add(id, value);
    }
}
