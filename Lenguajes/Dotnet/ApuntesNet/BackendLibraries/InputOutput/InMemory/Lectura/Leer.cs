namespace InMemory.Lectura;

internal class Leer
{
    internal static Task Read(MemoryStream streamEscrito)
    {
        streamEscrito.Seek(0, SeekOrigin.Begin);

        int buffer;
        while ((buffer = streamEscrito.ReadByte()) >= 0)
        {
            Console.Write(Convert.ToChar(buffer));
        }

        return Task.CompletedTask;
    }
}
