using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnmanagedMemory.UnsafeContext;

public class UnsafeWithMarshallAndStructs
{
    public static unsafe void Execute()
    {
        nint pointer = Marshal.AllocHGlobal(Unsafe.SizeOf<EstructuraBasica>());
        Escribir();
        Leer();

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
