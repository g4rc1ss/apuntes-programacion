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
    public unsafe void WriteStructMarshalWithUnsafe()
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
    public unsafe void WriteStructMarshalWithSpan()
    {
        // iterations = iterations * 1024 * 1024;
        nuint bufferSize = (nuint)(Unsafe.SizeOf<Coordinates>() * iterations);
        void* block = NativeMemory.Alloc(bufferSize);
        try
        {
            ref Coordinates myStruct = ref Unsafe.AsRef<Coordinates>(block);
            Span<Coordinates> span = MemoryMarshal.CreateSpan(ref myStruct, iterations);
            for (int i = 0; i < span.Length; i++)
            {
                span[i] = new Coordinates() { x = i, y = i };
            }
        }
        finally
        {
            NativeMemory.Free(block);
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

    [Benchmark]
    public unsafe void WriteStructObjMarshal()
    {
        nint pointer = nint.Zero;
        try
        {
            int size = Marshal.SizeOf<Estructura>();
            pointer = Marshal.AllocHGlobal(size * iterations);
            for (int i = 0; i < iterations; i++)
            {
                nint nextPointer = nint.Add(pointer, i * size);
                Marshal.StructureToPtr(
                    new Estructura() { nombre = "Nombre", numero = i },
                    nextPointer,
                    false
                );
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
    public void WriteStructWithObjs()
    {
        Estructura[] estructuras = new Estructura[iterations];

        for (int i = 0; i < iterations; i++)
        {
            estructuras[i] = new Estructura() { numero = i, nombre = "Nombre" };
        }
    }
}

internal struct Coordinates
{
    internal int x;
    internal int y;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
internal struct Estructura
{
    internal int numero;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
    internal string nombre;
}
