using System.Collections;

namespace Stacks;

public class StackCollection<T> : IEnumerable<T>
{
    private int index = -1;
    private T[] collection;

    public StackCollection()
    {
        collection = [];
    }

    public StackCollection(T[] collection)
    {
        this.collection = collection;
        index = collection.Length - 1;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new StackCollectionEnumerator<T>(collection);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Push(T item)
    {
        index++;
        if (index == collection.Length)
        {
            Array.Resize(ref collection, collection.Length + 1);
        }

        collection[index] = item;
    }

    public T Pop()
    {
        T? value = collection[index];
        Array.Resize(ref collection, collection.Length - 1);
        index--;
        return value;
    }
}
