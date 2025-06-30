using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace MicroBench;

[MemoryDiagnoser]
public class CollectionsWithSpan
{
    [Params(1, 10, 100, 1000, 100000, 1000000)]
    public int iterations;

    private List<CollectionWithSpanObj> _collectionWithSpanObjs;

    [GlobalSetup]
    public void Setup()
    {
        _collectionWithSpanObjs =
        [
            .. Enumerable.Range(0, iterations).Select(x => new CollectionWithSpanObj()),
        ];
    }

    [Benchmark]
    public void NormalIteration()
    {
        for (int i = 0; i < _collectionWithSpanObjs.Count; i++)
        {
            _collectionWithSpanObjs[i].Value = i;
        }
    }

    [Benchmark]
    public void SpanIteration()
    {
        Span<CollectionWithSpanObj> collectionSpan = CollectionsMarshal.AsSpan(
            _collectionWithSpanObjs
        );
        for (int i = 0; i < collectionSpan.Length; i++)
        {
            collectionSpan[i].Value = i;
        }
    }
}

internal class CollectionWithSpanObj
{
    internal int Value { get; set; }
}
