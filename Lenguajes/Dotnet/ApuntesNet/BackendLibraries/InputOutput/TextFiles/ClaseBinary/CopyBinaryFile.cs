namespace TextFiles.ClaseBinary;

public class CopyBinaryFile
{
    public CopyBinaryFile(string nombreArchivoFuente, string nombreArchivoDestino)
    {
        using BinaryReader? readBinaryFile = new(File.OpenRead(nombreArchivoFuente));
        using BinaryWriter? writeBinaryFile = new(File.OpenWrite(nombreArchivoDestino));
        for (byte data; readBinaryFile.PeekChar() != -1; )
        {
            data = readBinaryFile.ReadByte();
            writeBinaryFile.Write(data);
        }
    }
}
