// The other part of the client code constructs the actual chain.
using ChainOfResponsability;

MonkeyHandler? monkey = new();
SquirrelHandler? squirrel = new();
DogHandler? dog = new();

/**
 * Creamos un objeto que implemente clase abstracta AbstractHandler
 * Declaramos varias cadenas de responsabilidad
 * Si el contenido coincide con alguna de ellas, se ejecutara y acabara
 * Cuando no coincida, se pasará a la siguiente ejecucion
 *
 *
 */

monkey.SetNext(squirrel).SetNext(dog);

Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
Client.ClientCode(monkey);
Console.WriteLine();

Console.WriteLine("Subchain: Squirrel > Dog\n");
Client.ClientCode(squirrel);

Console.WriteLine("Pulsa una tecla para finalizar");
Console.ReadKey();
