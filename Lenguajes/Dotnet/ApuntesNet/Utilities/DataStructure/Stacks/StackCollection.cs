using System.Collections;

namespace Stacks;

public class StackCollection<T> : IEnumerable<T>
{
    private int _index = -1;
    private T[] _collection;

    public StackCollection()
    {
        _collection = [];
    }

    public StackCollection(T[] collection)
    {
        this._collection = collection;
        _index = collection.Length - 1;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new StackCollectionEnumerator<T>(_collection);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Push(T item)
    {
        _index++;
        if (_index == _collection.Length)
        {
            Array.Resize(ref _collection, _collection.Length + 1);
        }

        _collection[_index] = item;
    }

    public T Pop()
    {
        T? value = _collection[_index];
        Array.Resize(ref _collection, _collection.Length - 1);
        _index--;
        return value;
    }
}
