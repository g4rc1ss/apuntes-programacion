using System.Runtime;
using ManageMemoryGarbageCollect;

Console.WriteLine($"GC en ejecucion: IsServer? {GCSettings.IsServerGC}");
Console.WriteLine($"Latencia configurada de GC {GCSettings.LatencyMode}");

// Caso 1
// Tenemos una variable de ambito global que ocupa mucho espacio en memoria y necesitamos limpiarlo después
Func<double>? getMemory = () => GC.GetTotalMemory(false) / 1024.0 / 1024.0;

List<ObjetoPesado>? objetos = [];
for (int i = 0; i < 1_000_000_00; i++)
{
    objetos.Add(new(0, 1, "Hi"));
}

Console.WriteLine($"Total de memoria usara en el primer bucle {getMemory():F2} MB");

Console.WriteLine("Limpiamos la lista y forzamos una recolección de elementos");
objetos.Clear();
GC.Collect();
Console.WriteLine($"Memoria después de recolectar elementos {getMemory():F2}MB");

Console.WriteLine(
    "Redimensionamos la lista reservada al espacio real que ocupa y volvemos a ejecutar el GC"
);
objetos.TrimExcess();
GC.Collect();
Console.WriteLine($"Memoria después de recolectar elementos {getMemory():F2}MB");

// Caso 2
// El proceso que ocupa toda esta memoria está dentro de un ambito
static void ProcesarObjetos()
{
    List<ObjetoPesado>? objetos2 = [];
    for (int i = 0; i < 1_000_000_00; i++)
    {
        objetos2.Add(new(0, 1, "Hi"));
    }
}

// Latency normal
for (int i = 0; i < 5; i++)
{
    ProcesarObjetos();
    Console.WriteLine($"Total de memoria al salir del metodo {getMemory():F2} MB");

    Console.WriteLine($"Recolectamos los elementos");
    Console.WriteLine($"Memoria después de recolectar elementos {getMemory():F2}MB");
}

GC.Collect();

// Latency Batch
GCSettings.LatencyMode = GCLatencyMode.Batch;
Console.WriteLine($"Latencia configurada de GC {GCSettings.LatencyMode}");
for (int i = 0; i < 5; i++)
{
    ProcesarObjetos();
    Console.WriteLine($"Total de memoria al salir del metodo {getMemory():F2} MB");

    Console.WriteLine($"Recolectamos los elementos");
    Console.WriteLine($"Memoria después de recolectar elementos {getMemory():F2}MB");
}

GC.Collect();

// Latency Low
GCSettings.LatencyMode = GCLatencyMode.LowLatency;
Console.WriteLine($"Latencia configurada de GC {GCSettings.LatencyMode}");
for (int i = 0; i < 5; i++)
{
    ProcesarObjetos();
    Console.WriteLine($"Total de memoria al salir del metodo {getMemory():F2} MB");

    Console.WriteLine($"Recolectamos los elementos");
    Console.WriteLine($"Memoria después de recolectar elementos {getMemory():F2}MB");
}

GC.Collect();

Console.ReadKey();
