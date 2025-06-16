using InMemory.Copia;
using InMemory.Escritura;
using InMemory.Lectura;

MemoryStream? streamEscrito = await Escribir.WriteAsync();
await Leer.Read(streamEscrito);
await Copiar.CopyAsync(streamEscrito);

Console.ReadKey();
