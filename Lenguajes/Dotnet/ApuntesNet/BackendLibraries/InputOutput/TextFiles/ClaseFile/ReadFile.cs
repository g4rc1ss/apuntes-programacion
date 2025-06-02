using System.Text;

namespace TextFiles.ClaseFile;

internal class ReadFile
{
    public ReadFile(
        string nombreArchivoText,
        string nombreArchivoTextAsync,
        string nombreArchivoBytes,
        string nombreArchivoAllLines
    )
    {
        string? textoArchivoText = File.ReadAllText(nombreArchivoText);
        Task<string>? textoArchivoTextAsync = File.ReadAllTextAsync(nombreArchivoTextAsync);
        byte[]? textoArchivoBytes = File.ReadAllBytes(nombreArchivoBytes);
        _ = File.ReadAllLines(nombreArchivoAllLines);
        List<string>? textoArchivoLines = [.. File.ReadLines(nombreArchivoAllLines)];

        Console.WriteLine($"{nameof(textoArchivoText)}: {textoArchivoText}\n \n");
        Console.WriteLine($"{nameof(textoArchivoTextAsync)}: {textoArchivoTextAsync}\n \n");

        Console.WriteLine(
            $"{nameof(textoArchivoBytes)}: {Encoding.UTF8.GetString(textoArchivoBytes)}\n \n"
        );

        foreach (string? texto in textoArchivoLines)
        {
            string[] textoArchivoAllLines;
            Console.WriteLine($"{nameof(textoArchivoAllLines)}: {texto}");
        }
        Console.WriteLine("\n \n");

        foreach (string? texto in textoArchivoLines)
        {
            Console.WriteLine($"{nameof(textoArchivoLines)}: {texto}\n \n");
        }
    }
}
