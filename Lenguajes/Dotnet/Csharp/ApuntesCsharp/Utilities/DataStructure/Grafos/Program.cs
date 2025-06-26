using Grafos;

GraphObject<string, string>? graph = new();

graph.Add("Hola", "adios");
graph.Add("Hola", "buenas");

IEnumerable<string>? result = graph.Get("Hola");
foreach (string? data in result)
{
    Console.WriteLine(data);
}
