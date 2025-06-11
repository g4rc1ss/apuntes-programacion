using AsyncAwait.Async;

Asincronia? asincronia = new();

Console.WriteLine("Ejemplo de codigo asincrono enlazado a CPU");
Task? tareaCpu = asincronia.CpuAsync();

Console.WriteLine("Ejemplo de codido asincrono E/S");
Task? tareaES = asincronia.ESAsync();

Console.WriteLine("Ejemplo de codido asincrono en bucles con IAsyncEnumerable");
Task? tareaForeachAsync = asincronia.ExecuteIEnumerableAsync();

await Task.WhenAll(tareaCpu, tareaES, tareaForeachAsync);
