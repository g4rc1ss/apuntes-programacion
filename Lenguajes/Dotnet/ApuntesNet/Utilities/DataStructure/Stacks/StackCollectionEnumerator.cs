using System.Collections;

namespace Stacks;

public class StackCollectionEnumerator<T>(T[] collection) : IEnumerator<T>
{
    private int _index;
    public T? Current { get; internal set; }

    object? IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if ((uint)_index < collection.Length)
        {
            Current = collection[_index];
            _index++;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _index = 0;
        Current = default;
    }

    public void Dispose()
    {
        Current = default;
        collection = null;
        GC.SuppressFinalize(this);
    }
}
