using System.Collections;

namespace DeferredExecutionYield.ExplicitEnumerator.EnumerableClass;

internal class ExplicitEnumerator : IEnumerator<int>
{
    public int Current { get; set; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public bool MoveNext()
    {
        if (Current < 100)
        {
            Current++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
