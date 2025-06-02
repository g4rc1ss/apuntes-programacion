namespace InMemory.Copia;

internal class Copiar
{
    public Copiar() { }

    internal static async Task Copy(MemoryStream streamEscrito)
    {
        using MemoryStream? memoryStream = new();

        await streamEscrito.CopyToAsync(memoryStream);
    }
}
