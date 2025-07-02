using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace MicroBench;

[MemoryDiagnoser]
public class GCHandleApi
{
    [Params(1, 10, 100, 1000, 10000)]
    public int iterations = 2 * 1024 * 1024 * 100;

    [GlobalSetup]
    public void Setup() { }

    [Benchmark]
    public void IterateObjArray()
    {
        int[] array = new int[iterations];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        for (int i = 0; i < array.Length; i++)
        {
            int x = array[i];
        }
    }

    [Benchmark]
    public unsafe void IterateObjWithGCHandle()
    {
        GCHandle gc = GCHandle.Alloc(new int[iterations], GCHandleType.Pinned);
        try
        {
            nint pointer = gc.AddrOfPinnedObject();
            nint nextPointer = pointer;
            for (int i = 0; i < iterations; i++)
            {
                nextPointer = nint.Add(pointer, sizeof(int) * i);
                Unsafe.Write(nextPointer.ToPointer(), i);
            }

            for (int i = 0; i < iterations; i++)
            {
                nextPointer = nint.Add(pointer, sizeof(int) * i);
                int x = Unsafe.Read<int>(nextPointer.ToPointer());
            }
        }
        finally
        {
            gc.Free();
        }
    }
}

internal record GCHandleObj(string Property);
