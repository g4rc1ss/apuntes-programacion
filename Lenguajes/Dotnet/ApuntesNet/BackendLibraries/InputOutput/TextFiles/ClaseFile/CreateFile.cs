namespace TextFiles.ClaseFile;

internal class CreateFile
{
    public CreateFile(params string[] archivosCrear)
    {
        // Creamos el archivo en la ruta correspondiente
        foreach (string? archivo in archivosCrear)
        {
            using FileStream? file = File.Create(archivo);
            Console.WriteLine($"Archivo {archivo} creado");
        }
    }
}
