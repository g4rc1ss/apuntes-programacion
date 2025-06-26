using BenchmarkDotNet.Attributes;

namespace UnmanagedMemoryVsNormalBenchmark;

[MemoryDiagnoser]
public class StackallocMemory
{
    [Benchmark]
    public unsafe void ExecuteWithPointers()
    {
        int* number = stackalloc int[10000];

        for (int i = 0; i < 10000; i++)
        {
            number[i] = 1 * sizeof(int);
        }
    }

    [Benchmark]
    public unsafe void ExecuteWithSpan()
    {
        // No puede ser usado fuera de métodos
        // Es mejor que usar punteros crudos, ya que abstrae para manejarlo de forma segura
        Span<int> number = stackalloc int[10000];

        for (int i = 0; i < number.Length; i++)
        {
            number[i] = 1 * sizeof(int);
        }
    }

    [Benchmark]
    public void ExecuteWithNormalMode()
    {
        // No puede ser usado fuera de métodos
        // Es mejor que usar punteros crudos, ya que abstrae para manejarlo de forma segura
        int[]? number = new int[10000];

        for (int i = 0; i < number.Length; i++)
        {
            number[i] = 1 * sizeof(int);
        }
    }
}
