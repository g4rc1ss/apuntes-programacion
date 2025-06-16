using System.Text;

namespace InMemory.Escritura;

internal class Escribir
{
    internal static async Task<MemoryStream> WriteAsync()
    {
        byte[]? firstString = new UnicodeEncoding().GetBytes("Texto a convertir en bytes");
        byte[]? secondString = new UnicodeEncoding().GetBytes("Texto a agregar");

        MemoryStream? memoryStream = new();

        await memoryStream.WriteAsync(firstString);

        foreach (byte item in secondString)
        {
            memoryStream.WriteByte(item);
        }

        return memoryStream;
    }
}
