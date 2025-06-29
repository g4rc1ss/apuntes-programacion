using BenchmarkDotNet.Attributes;

namespace MicroBench;

[MemoryDiagnoser]
public class StringWithSpan
{
    private readonly string _text = "Texto de prueba para benchmarking con Strings";

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
}
