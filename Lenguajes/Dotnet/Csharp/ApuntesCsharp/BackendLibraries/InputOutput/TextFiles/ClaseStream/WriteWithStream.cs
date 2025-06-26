namespace TextFiles.ClaseStream;

internal class WriteWithStream
{
    public WriteWithStream(string nombreArchivo)
    {
        string? textoEscribir =
            "Este es el texto que se esta \n escribiendo con la Clase Stream de .NET";

        using StreamWriter? writeFile = new(nombreArchivo);
        writeFile.Write(textoEscribir);
    }
}
