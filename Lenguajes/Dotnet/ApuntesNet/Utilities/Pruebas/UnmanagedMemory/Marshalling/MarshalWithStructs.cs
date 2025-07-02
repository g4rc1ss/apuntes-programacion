using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UnmanagedMemory.Marshalling;

public static class MarshalWithStructs
{
    public static void Execute()
    {
        IntPtr pointer = IntPtr.Zero;
        try
        {
            Console.WriteLine("Reservamos memoria no administrada con Marshal");
            int objectLen = Marshal.SizeOf<Estructura>();
            long size = 2L * 1024 * 1024 * 100;
            long numberOfObj = size / objectLen;
            pointer = Marshal.AllocHGlobal((nint)size);

            Console.WriteLine("Rellenamos la memoria reservada no administrada");
            nint nextPointer = pointer;
            for (long i = 0; i < numberOfObj; i++)
            {
                string nombre = $"Nombre {i}";
                Estructura obj = new() { numero = i, name = nombre };
                Marshal.StructureToPtr(obj, nextPointer, false);
                nextPointer = nint.Add(nextPointer, objectLen);
            }

            nextPointer = pointer;
            for (long i = 0; i < numberOfObj; i++)
            {
                Estructura readObj = Marshal.PtrToStructure<Estructura>(nextPointer);
                // Console.Write(readObj.numero);

                string nombre = readObj.name;
                // Console.WriteLine(nombre);
                nextPointer = nint.Add(nextPointer, objectLen);
            }

            Console.WriteLine($"Memoria que usa el proceso: {GC.GetTotalMemory(true)}");
        }
        catch (Exception)
        {
            Console.WriteLine("No se pudo asignar la memoria requerida.");
        }
        finally
        {
            if (pointer != IntPtr.Zero)
            {
                GC.Collect();
                Marshal.DestroyStructure<Estructura>(pointer);
                Marshal.FreeHGlobal(pointer);
                Console.WriteLine("La memoria no administrada ha sido liberada.");
            }

            Console.WriteLine(
                $"Memoria que usa el proceso: {Process.GetCurrentProcess().PrivateMemorySize64}"
            );
        }
    }
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
internal struct Estructura
{
    internal long numero;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    internal string name;
}
