using Bridge;
using Bridge.Implementacion;

Client? client = new();

Abstraction abstraction;

// Recibimos o creamos una clase de abstraccion con la implementacion correspondiente
abstraction = new Abstraction(new ConcreteImplementationA());

// El cliente sin saber cual es la instancia que recibe, la utiliza.
client.ClientCode(abstraction);

Console.WriteLine();

abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
client.ClientCode(abstraction);

Console.ReadKey();
