using System.Collections;

namespace Queues;

public class Queue<T> : IEnumerable<T>
{
    private int _indexToAdd = -1;
    private T[] _collection;

    public Queue()
    {
        _collection = [];
    }

    public Queue(T[] collection)
    {
        this._collection = collection;
        _indexToAdd = collection.Length - 1;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new QueueEnumerator<T>(_collection);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enqueue(T item)
    {
        _indexToAdd++;
        if (_indexToAdd == _collection.Length)
        {
            Array.Resize(ref _collection, _collection.Length + 1);
        }

        _collection[_indexToAdd] = item;
    }

    public T Dequeue()
    {
        T? value = _collection[0];
        _collection = [.. _collection.Skip(1)];
        _indexToAdd--;
        return value;
    }
}
