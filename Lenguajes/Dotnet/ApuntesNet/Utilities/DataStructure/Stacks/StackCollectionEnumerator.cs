using System.Collections;

namespace Stacks;

public class StackCollectionEnumerator<T>(T[] collection) : IEnumerator<T>
{
    private int index;
    public T? Current { get; internal set; }

    object? IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if ((uint)index < collection.Length)
        {
            Current = collection[index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        index = 0;
        Current = default;
    }

    public void Dispose()
    {
        Current = default;
        collection = null;
    }
}
