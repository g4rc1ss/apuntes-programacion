using System.Collections;

namespace Queues;

public class Queue<T> : IEnumerable<T>
{
    private int indexToAdd = -1;
    private T[] collection;

    public Queue()
    {
        collection = [];
    }

    public Queue(T[] collection)
    {
        this.collection = collection;
        indexToAdd = collection.Length - 1;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new QueueEnumerator<T>(collection);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enqueue(T item)
    {
        indexToAdd++;
        if (indexToAdd == collection.Length)
        {
            Array.Resize(ref collection, collection.Length + 1);
        }

        collection[indexToAdd] = item;
    }

    public T Dequeue()
    {
        T? value = collection[0];
        collection = [.. collection.Skip(1)];
        indexToAdd--;
        return value;
    }
}
