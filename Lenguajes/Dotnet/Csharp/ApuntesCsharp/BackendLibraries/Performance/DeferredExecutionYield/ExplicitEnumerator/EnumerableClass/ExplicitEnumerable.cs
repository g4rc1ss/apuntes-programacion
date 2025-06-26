using System.Collections;

namespace DeferredExecutionYield.ExplicitEnumerator.EnumerableClass;

internal class ExplicitEnumerable : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        return new ExplicitEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
