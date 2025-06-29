using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace MicroBench;

[MemoryDiagnoser]
public class MarshallApi
{
    private const long SIZE = 1L * 1024 * 1024 * 1024;
    private const long NUMBER_OF_INTEGERS = SIZE / sizeof(int);
    private const int SIZE_OBJECTS_ARRAY = 1_000_000;

    [Benchmark]
    public void WriteIntWithMarshall()
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
    public void WriteIntArrayWithManagement()
    {
        List<int>? listaInt = [];
        for (int i = 0; i < SIZE; i++)
        {
            listaInt.Add(i);
        }
    }

    [Benchmark]
    public void WriteObjectsWithMarshall()
    {
        IntPtr pointer = IntPtr.Zero;
        try
        {
            int objectLen = Unsafe.SizeOf<Objeto>();
            int size = objectLen * SIZE_OBJECTS_ARRAY;
            pointer = Marshal.AllocHGlobal(size);

            nint nextPointer = pointer;
            for (long i = 0; i < SIZE_OBJECTS_ARRAY; i++)
            {
                unsafe
                {
                    Objeto obj = new($"{i}", $"{i}");
                    Unsafe.Write(nextPointer.ToPointer(), obj);
                    nextPointer = nint.Add(pointer, objectLen);
                }
            }
        }
        finally
        {
            if (pointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pointer);
            }
        }
    }

    [Benchmark]
    public void WriteArrayObjWithManagements()
    {
        Objeto[] array = new Objeto[SIZE_OBJECTS_ARRAY];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = new Objeto($"{i}", $"{i}");
        }
    }
}

record Objeto(string Name, string Subname);
