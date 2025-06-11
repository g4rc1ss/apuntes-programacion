using JsonFiles.JSON;
using JsonFiles.Read;
using JsonFiles.Write;

// Creamos un archivo JSON para indicar la ruta
ClaseParaJSON? crearJSON = new() { Ruta = "archivo.txt" };

// Usamos JSON
await JsonWriteSerialization.UsingJSONAsync(crearJSON);
Console.WriteLine("\n-------------------------------------------------------------\n");
await JsonReadDeserialize.UsingJSONAsync();
