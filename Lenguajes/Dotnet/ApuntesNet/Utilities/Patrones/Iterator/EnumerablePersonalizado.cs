using System.Collections;

namespace Iterator;

public class EnumerablePersonalizado<T>(int maxIndex) : IEnumerable<T>
{
    public T[] enumerable = new T[maxIndex];

    public IEnumerator<T> GetEnumerator()
    {
        return new Iterator<T>(enumerable);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
