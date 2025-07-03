namespace TextFiles.ClaseBinary;

public class CopyBinaryFile
{
    public CopyBinaryFile(string nombreArchivoFuente, string nombreArchivoDestino)
    {
        using FileStream fileReader = File.OpenRead(nombreArchivoFuente);
        using BinaryReader? readBinaryFile = new(fileReader);

        using FileStream fileWriter = File.OpenWrite(nombreArchivoDestino);
        using BinaryWriter? writeBinaryFile = new(fileWriter);
        for (byte data; readBinaryFile.PeekChar() != -1; )
        {
            data = readBinaryFile.ReadByte();
            writeBinaryFile.Write(data);
        }
    }
}
