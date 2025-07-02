using System.Buffers;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace UnmanagedMemory.Marshalling;

public static class MarshallWithClass
{
    public static unsafe void Execute()
    {
        int size = 2 * 1024 * 1024;

        ArrayPool<Pointer> arrayPool = ArrayPool<Pointer>.Shared;
        Pointer[] pointers = arrayPool.Rent(size);
        try
        {
            Console.WriteLine("Reservamos memoria no administrada con Marshal");

            Console.WriteLine("Rellenamos la memoria reservada no administrada");
            for (int i = 0; i < size; i++)
            {
                string nombre = $"Nombre {i}";
                Clase obj = new(nombre, "apellido");
                byte[] content = JsonSerializer.SerializeToUtf8Bytes(obj);
                nint pointer = Marshal.AllocHGlobal(content.Length);
                Marshal.Copy(content, 0, pointer, content.Length);

                pointers[i] = new Pointer(pointer, content.Length);
            }

            for (int i = 0; i < pointers.Length; i++)
            {
                byte[] content = new byte[pointers[i].size];
                Marshal.Copy(pointers[i].pointer, content, 0, pointers[i].size);
                Clase? readObj = JsonSerializer.Deserialize<Clase>(content);

                string nombre = readObj.Name;
            }

            Console.WriteLine($"Memoria que usa el proceso: {GC.GetTotalMemory(true)}");
        }
        catch (Exception)
        {
            Console.WriteLine("No se pudo asignar la memoria requerida.");
        }
        finally
        {
            if (pointers.Length != 0)
            {
                foreach (Pointer pointer in pointers)
                {
                    Marshal.FreeHGlobal(pointer.pointer);
                }
                arrayPool.Return(pointers, true);
                Console.WriteLine("La memoria no administrada ha sido liberada.");
            }

            Console.WriteLine(
                $"Memoria que usa el proceso: {Process.GetCurrentProcess().PrivateMemorySize64}"
            );
        }
    }
}

internal record Clase(string Name, string Surname);

internal struct Pointer
{
    internal IntPtr pointer;
    internal int size;

    internal Pointer(IntPtr pointer, int size)
    {
        this.pointer = pointer;
        this.size = size;
    }
}
