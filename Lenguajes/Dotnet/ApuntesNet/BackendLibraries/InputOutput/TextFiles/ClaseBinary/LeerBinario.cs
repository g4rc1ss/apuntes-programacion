namespace TextFiles.ClaseBinary;

public class LeerBinario
{
    public LeerBinario(string nombreArchivo)
    {
        // Apertura del archivo `ArchivoBinario.bin` en modo lectura:
        // Muestra la información tal cual está escrita en el archivo binario:
        using FileStream? fs = new(nombreArchivo, FileMode.Open, FileAccess.Read);
        Console.Write(Environment.NewLine);
        // Lectura y conversión de los datos binarios en el tipo de
        // correspondiente:

        // Posiciona el cursor desde se iniciara la lectura del
        // archivo `ArchivoBinario`:
        fs.Position = 0;
        using BinaryReader? br = new(fs);
        Console.WriteLine(br.ReadDecimal());
        Console.WriteLine(br.ReadString());
        Console.WriteLine(br.ReadString());
        Console.WriteLine(br.ReadChar());
    }
}
