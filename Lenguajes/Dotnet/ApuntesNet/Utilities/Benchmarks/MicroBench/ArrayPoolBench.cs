using System.Buffers;
using BenchmarkDotNet.Attributes;

namespace MicroBench;

[MemoryDiagnoser]
public class ArrayPoolBench
{
    [Params(1, 10, 100, 1000, 100000)]
    public int iterations;

    // Un caracter tiene 2 bytes
    // 2 * 1024 = 2048kb
    // 2048 * 1024b = 2MB
    private readonly string _data = new('A', 1024);

    [Benchmark]
    public void AddDataToStringArrayPool()
    {
        ArrayPool<string> arrayPool = ArrayPool<string>.Shared;
        string[] array = arrayPool.Rent(iterations);

        try
        {
            for (int i = 0; i < iterations; i++)
            {
                array[i] = _data;
            }
        }
        finally
        {
            arrayPool.Return(array);
        }
    }

    [Benchmark]
    public void AddDataToStringArray()
    {
        string[] array = new string[iterations];

        for (int i = 0; i < iterations; i++)
        {
            array[i] = _data;
        }
    }
}
