using System.Text;

namespace TextFiles.ClaseFile;

internal class WriteFile
{
    public WriteFile(
        string nombreArchivoText,
        string nombreArchivoTextAsync,
        string nombreArchivoBytes,
        string nombreArchivoAllLines
    )
    {
        string? textoEscribir =
            "Este es el texto que se esta \n escribiendo con la Clase File de .NET";
        File.WriteAllText(nombreArchivoText, textoEscribir);
        File.WriteAllTextAsync(nombreArchivoTextAsync, textoEscribir);
        File.WriteAllBytes(nombreArchivoBytes, Encoding.UTF8.GetBytes(textoEscribir));
        File.WriteAllLines(nombreArchivoAllLines, textoEscribir.Split('\n'));
    }
}
