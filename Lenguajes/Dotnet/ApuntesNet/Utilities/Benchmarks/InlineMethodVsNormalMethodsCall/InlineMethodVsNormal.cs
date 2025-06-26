using BenchmarkDotNet.Attributes;

namespace InlineMethodVsNormalMethodsCall;

[MemoryDiagnoser]
public class InlineMethodVsNormal
{
    [Benchmark]
    public void ExecuteMethod()
    {
    }

    [Benchmark]
    public void ExecuteInlineMethod()
    {
    }
}