using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnmanagedMemory;

public static class MarshalWithUnsafe
{
    public static void Execute()
    {
        IntPtr pointer = IntPtr.Zero;
        try
        {
            Console.WriteLine("Reservamos memoria no administrada con Marshal");
            int objectLen = Unsafe.SizeOf<Objeto>();
            int size = objectLen * 1_000_000;
            pointer = Marshal.AllocHGlobal(size);

            Console.WriteLine("Rellenamos la memoria reservada no administrada");
            nint nextPointer = pointer;
            for (long i = 0; i < 1_000_000; i++)
            {
                unsafe
                {
                    Objeto obj = new($"{i}", $"{i}");
                    Unsafe.Write(nextPointer.ToPointer(), obj);
                    Objeto readObj = Unsafe.Read<Objeto>(nextPointer.ToPointer());
                    nextPointer = nint.Add(pointer, objectLen);
                }
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
                Marshal.FreeHGlobal(pointer);
                GC.Collect();
                Console.WriteLine("La memoria no administrada ha sido liberada.");
            }

            Console.WriteLine(
                $"Memoria que usa el proceso: {Process.GetCurrentProcess().PrivateMemorySize64}"
            );
        }
    }
}

record Objeto(string Name, string Subname);
