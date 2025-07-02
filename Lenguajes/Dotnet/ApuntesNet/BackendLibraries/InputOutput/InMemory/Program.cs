using InMemory.Copia;
using InMemory.Escritura;
using InMemory.Lectura;

using MemoryStream? streamEscrito = await Escribir.WriteAsync();
await Leer.Read(streamEscrito);
await Copiar.CopyAsync(streamEscrito);

Console.ReadKey();
