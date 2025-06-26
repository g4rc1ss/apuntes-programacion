using Prototype;

ClasePrototype? prototype = new("contraseña 1")
{
    Name = "Nombre",
    Description = "Descripcion",
    Age = 20,
    FechaNacimiento = DateTime.MinValue,
};
Console.WriteLine(prototype.ToString());

ClasePrototype? copia = (ClasePrototype)prototype.Clone();
Console.WriteLine(copia.ToString());

Console.WriteLine("------------------------ cambios ------------------------");

prototype.Name = "Nombre modificado";
prototype.Description = "Descripcion modificada";
prototype.Age = 12;
prototype.FechaNacimiento = DateTime.Now;
Console.WriteLine(prototype.ToString());

copia.Name = "Nombre copia modificada";
copia.Description = "Descripcion copia modificada";
copia.Age = 56;
copia.FechaNacimiento = DateTime.Now;
Console.WriteLine(copia.ToString());

Console.ReadKey();
