using System.Collections;

namespace Iterator;

public class Iterator<T>(T[] collection) : IEnumerator<T>
{
    private int _indiceActual = -1;
    private bool _disposedValue = false;

    public T Current { get; private set; } = default;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        Console.WriteLine("Pasando por el Iterator personalizado");
        if (++_indiceActual >= collection.Length)
        {
            return false;
        }
        else
        {
            Current = collection[_indiceActual];
        }
        return true;
    }

    public void Reset()
    {
        _indiceActual = -1;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                collection = null;
                Current = default;
            }
        }
        _disposedValue = true;
    }
}
