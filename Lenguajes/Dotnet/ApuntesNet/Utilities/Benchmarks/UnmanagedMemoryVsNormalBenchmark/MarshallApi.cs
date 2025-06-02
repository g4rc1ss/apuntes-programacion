using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace UnmanagedMemoryVsNormalBenchmark;

[MemoryDiagnoser]
public class MarshallApi
{
    private const long SIZE = 1L * 1024 * 1024 * 1024;
    private const long NUMBER_OF_INTEGERS = SIZE / sizeof(int);

    [Benchmark]
    public void WriteMemoryOnMarshal()
    {
        IntPtr pointer = IntPtr.Zero;
        try
        {
            pointer = Marshal.AllocHGlobal(new nint(SIZE));
            for (long i = 0; i < NUMBER_OF_INTEGERS; i++)
            {
                // Calculamos la dirección de memoria de cada entero
                IntPtr ptr = IntPtr.Add(pointer, (int)(i * sizeof(int)));

                // Escribimos el valor entero (por ejemplo, asignar el valor de i)
                Marshal.WriteInt32(ptr, (int)i);
            }
        }
        finally
        {
            Marshal.FreeHGlobal(pointer);
        }
    }

    [Benchmark]
    public void WriteMemoryWithManagement()
    {
        List<int>? listaInt = [];
        for (int i = 0; i < SIZE; i++)
        {
            listaInt.Add(i);
        }
    }
}
