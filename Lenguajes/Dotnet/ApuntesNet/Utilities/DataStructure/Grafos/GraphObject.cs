namespace Grafos;

public class GraphObject<TKey, TValue>
{
    private readonly IDictionary<TKey, IEnumerable<TValue>> _graph;

    public GraphObject()
    {
        _graph = new Dictionary<TKey, IEnumerable<TValue>>();
    }

    public void Add(TKey key, TValue value)
    {
        bool exists = _graph.TryGetValue(key, out IEnumerable<TValue>? result);
        if (!exists)
        {
            _graph.Add(key, [value]);
            return;
        }

        if (result is null)
        {
            result = [value];
        }
        else
        {
            _graph[key] = result.Append(value);
        }
    }

    public IEnumerable<TValue> Get(TKey key)
    {
        return _graph[key];
    }
}
