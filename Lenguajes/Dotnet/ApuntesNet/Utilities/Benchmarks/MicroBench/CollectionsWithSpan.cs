using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace MicroBench;

[MemoryDiagnoser]
public class CollectionsWithSpan
{
    [Params(1, 10, 100, 1000, 100000, 1000000)]
    public int iterations;

    private List<CollectionWithSpanObj> _collectionWithSpanObjs;

    private CollectionWithSpanObj[] _collectionWithSpanObjsArray;

    [GlobalSetup]
    public void Setup()
    {
        _collectionWithSpanObjs =
        [
            .. Enumerable.Range(0, iterations).Select(x => new CollectionWithSpanObj()),
        ];
        _collectionWithSpanObjsArray = [.. _collectionWithSpanObjs];
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

    [Benchmark]
    public void NormalIterationArray()
    {
        for (int i = 0; i < _collectionWithSpanObjsArray.Length; i++)
        {
            _collectionWithSpanObjsArray[i].Value = i;
        }
    }

    [Benchmark]
    public void SpanIterationArray()
    {
        Span<CollectionWithSpanObj> collectionSpan = _collectionWithSpanObjsArray;
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
