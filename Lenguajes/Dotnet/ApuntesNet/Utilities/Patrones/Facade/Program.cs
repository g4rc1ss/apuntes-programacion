using Facade.Patron;

// Inicializamos la clase fachada
Fachada? fachada = new();

// Ejecutamos la clase fachada sin saber que hace por dentro
Console.WriteLine(fachada.Operation());

Console.ReadKey();
