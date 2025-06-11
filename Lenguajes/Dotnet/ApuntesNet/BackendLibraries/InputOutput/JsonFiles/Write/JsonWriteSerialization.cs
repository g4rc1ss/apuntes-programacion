using System.Text.Json;
using JsonFiles.JSON;

namespace JsonFiles.Write;

public class JsonWriteSerialization
{
    public static async Task UsingJSONAsync(ClaseParaJSON json)
    {
        using FileStream? jsonStream = File.OpenWrite("ruta.json");
        await JsonSerializer.SerializeAsync(jsonStream, json);
    }
}
