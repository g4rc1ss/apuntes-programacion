using Iterator;

EnumerablePersonalizado<string>? coleccionPersonalizado = new(2);
coleccionPersonalizado.enumerable[0] = "Hola";
coleccionPersonalizado.enumerable[1] = "Adios";

foreach (string? item in coleccionPersonalizado)
{
    Console.WriteLine(item);
}

Console.WriteLine("Pulsa una tecla para finalizar");
Console.ReadKey();
