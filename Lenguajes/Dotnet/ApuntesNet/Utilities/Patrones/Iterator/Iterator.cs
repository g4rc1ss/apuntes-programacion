using System.Collections;

namespace Iterator;

public class Iterator<T>(T[] collection) : IEnumerator<T>
{
    private int indiceActual = -1;
    private bool disposedValue = false;

    public T Current { get; private set; } = default;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        Console.WriteLine("Pasando por el Iterator personalizado");
        if (++indiceActual >= collection.Length)
        {
            return false;
        }
        else
        {
            Current = collection[indiceActual];
        }
        return true;
    }

    public void Reset()
    {
        indiceActual = -1;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                collection = null;
                Current = default;
            }
        }
        disposedValue = true;
    }
}
