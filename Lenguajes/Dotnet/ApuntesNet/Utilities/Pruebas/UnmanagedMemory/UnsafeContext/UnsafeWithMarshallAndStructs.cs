using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnmanagedMemory.UnsafeContext;

public class UnsafeWithMarshallAndStructs
{
    public static unsafe void Execute()
    {
        nint pointer = Marshal.AllocHGlobal(Unsafe.SizeOf<EstructuraBasica>());
        try
        {
            Escribir();
            Leer();
        }
        finally
        {
            Marshal.FreeHGlobal(pointer);
        }

        // Otra forma:
        int count = 2;
        nuint bufferSize = (nuint)(Unsafe.SizeOf<EstructuraBasica>() * count);
        void* block = NativeMemory.Alloc(bufferSize);
        try
        {
            ref EstructuraBasica myStruct = ref Unsafe.AsRef<EstructuraBasica>(block);
            Span<EstructuraBasica> span = MemoryMarshal.CreateSpan(ref myStruct, count);
            for (int i = 0; i < span.Length; i++)
            {
                span[i] = new EstructuraBasica()
                {
                    flotante = 2,
                    letra = 'A',
                    numero = 2,
                };
            }
        }
        finally
        {
            NativeMemory.Free(block);
        }

        void Leer()
        {
            EstructuraBasica objetoLectura = Unsafe.Read<EstructuraBasica>(pointer.ToPointer());
            Console.Write(objetoLectura.flotante);
            Console.Write(objetoLectura.letra);
        }

        void Escribir()
        {
            Unsafe.Write(
                pointer.ToPointer(),
                new EstructuraBasica()
                {
                    numero = 100,
                    flotante = 100.5f,
                    letra = 'a',
                }
            );
        }
    }
}

internal struct EstructuraBasica
{
    internal int numero;
    internal float flotante;
    internal char letra;
}
