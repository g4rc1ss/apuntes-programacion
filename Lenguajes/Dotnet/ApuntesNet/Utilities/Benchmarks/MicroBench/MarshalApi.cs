using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace MicroBench;

[MemoryDiagnoser]
public class MarshalApi
{
    [Params(1, 10, 100, 1000, 10000)]
    public int iterations = 10;

    [Benchmark]
    public unsafe void WriteMarshalWithUnsafe()
    {
        nint pointer = nint.Zero;
        try
        {
            int size = Unsafe.SizeOf<Coordinates>();
            pointer = Marshal.AllocHGlobal(size * iterations);
            for (int i = 0; i < iterations; i++)
            {
                Unsafe.Write(pointer.ToPointer(), new Coordinates() { x = i, y = i });
            }
        }
        finally
        {
            if (pointer != nint.Zero)
            {
                Marshal.FreeHGlobal(pointer);
            }
        }
    }

    [Benchmark]
    public void WriteStruct()
    {
        Coordinates[] coordinates = new Coordinates[iterations];

        for (int i = 0; i < iterations; i++)
        {
            coordinates[i] = new Coordinates() { x = i, y = i };
        }
    }
}

internal struct Coordinates
{
    internal int x;
    internal int y;
}
