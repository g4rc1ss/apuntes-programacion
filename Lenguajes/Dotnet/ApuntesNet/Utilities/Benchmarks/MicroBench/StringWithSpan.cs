using BenchmarkDotNet.Attributes;

namespace MicroBench;

[MemoryDiagnoser]
public class StringWithSpan
{
    private readonly string _text = "Texto , de , prueba , para benchmarking , con Strings";

    [Benchmark]
    public void SubString()
    {
        string result = _text.Substring(4, 5);
    }

    [Benchmark]
    public void SubstringSpan()
    {
        ReadOnlySpan<char> result = _text.AsSpan().Slice(4, 5);
    }

    [Benchmark]
    public void SubstringSpanAndCreateString()
    {
        ReadOnlySpan<char> result = _text.AsSpan().Slice(4, 5);
        string s = new(result);
    }

    [Benchmark]
    public void Split()
    {
        string[] result = _text.Split(',');
    }

    [Benchmark]
    public void SplitSpan()
    {
        MemoryExtensions.SpanSplitEnumerator<char> result = _text.AsSpan().Split(',');
    }

    [Benchmark]
    public void SplitSpanAndRead()
    {
        ReadOnlySpan<char> textSpan = _text.AsSpan();
        MemoryExtensions.SpanSplitEnumerator<char> result = textSpan.Split(',');

        foreach (Range range in result)
        {
            ReadOnlySpan<char> slice = textSpan.Slice(
                range.Start.Value,
                range.End.Value - range.Start.Value
            );
        }
    }
}
