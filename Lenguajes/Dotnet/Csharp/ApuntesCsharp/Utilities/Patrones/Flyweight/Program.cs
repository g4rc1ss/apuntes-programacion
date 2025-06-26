using Flyweight;

ObjetoGuardar? guardar = new()
{
    Nombre = "Hola",
    Apellidos = "Prueba",
    Descripcion = "De cache",
};

FlyweightCache.SetValue("objeto", guardar);
FlyweightCache.SetValue("1", "Holaaaaaaaa");

FlyweightCache.TryGetValue("objeto", out ObjetoGuardar objeto);
Console.WriteLine(objeto);

FlyweightCache.TryGetValue("1", out object? objeto1);
Console.WriteLine(objeto1.ToString());

Console.ReadKey();
