namespace TextFiles.ClaseStream;

internal class ReadWithStream
{
    public ReadWithStream(string nombreArchivo)
    {
        using (StreamReader? readFile = new(nombreArchivo))
        {
            Console.WriteLine($"Leido hasta el final - {readFile.ReadToEnd()}");
        }

        using (StreamReader? readFile = new(nombreArchivo))
        {
            Console.WriteLine($"\n Leido caracter a caracter - ");
            while (readFile.Peek() >= 1)
            {
                Console.Write((char)readFile.Read());
            }
        }

        using (StreamReader? readFile = new(nombreArchivo))
        {
            Console.WriteLine($"\n \n Leido por Bloques - ");
            char[]? buffer = new char[5];
            while (!readFile.EndOfStream)
            {
                int lenght = readFile.ReadBlock(buffer, 0, buffer.Length);
                Console.WriteLine(new string(buffer, 0, lenght));
            }
        }
    }
}
