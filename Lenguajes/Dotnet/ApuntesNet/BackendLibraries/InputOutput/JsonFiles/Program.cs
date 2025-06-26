using JsonFiles.JSON;
using JsonFiles.Read;
using JsonFiles.Write;

// Creamos un archivo JSON para indicar la ruta
ClaseParaJson? crearJson = new() { Ruta = "archivo.txt" };

// Usamos JSON
await JsonWriteSerialization.UsingJsonAsync(crearJson);
Console.WriteLine("\n-------------------------------------------------------------\n");
await JsonReadDeserialize.UsingJsonAsync();
