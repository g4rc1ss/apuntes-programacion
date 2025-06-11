using System.Text.Json;
using JsonFiles.JSON;

namespace JsonFiles.Read;

public class JsonReadDeserialize
{
    public static async Task UsingJSONAsync()
    {
        using FileStream? jsonStream = File.Open("ruta.json", FileMode.Open, FileAccess.Read);
        ClaseParaJSON? localizacion = await JsonSerializer.DeserializeAsync<ClaseParaJSON>(
            jsonStream
        );

        Console.WriteLine("JSON Deserializado:");
        Console.WriteLine(localizacion.Ruta);
    }
}
