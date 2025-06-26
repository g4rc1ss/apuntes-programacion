using System.Buffers;

namespace UnmanagedMemory;

public static class ArrayPoolShared
{
    public static void Execute()
    {
        string[] pool = ArrayPool<string>.Shared.Rent(1_000_000);
        try
        {
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i] = "Hello World";
            }
        }
        catch (Exception)
        {
            Console.WriteLine("No se pudo asignar la memoria requerida.");
        }
        finally
        {
            ArrayPool<string>.Shared.Return(pool);
        }
    }
}
