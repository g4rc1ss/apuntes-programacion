// The client code.
using State;

Context? context = new(new ConcreteStateA());
context.Request1();
context.Request2();

Console.WriteLine("Pulsa una tecla para finalizar");
Console.ReadKey();
