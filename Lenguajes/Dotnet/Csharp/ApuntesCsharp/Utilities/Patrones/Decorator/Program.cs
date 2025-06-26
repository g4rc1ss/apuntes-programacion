using Decorator;

Client? client = new();

ConcreteComponent? simple = new();
Console.WriteLine("Client: I get a simple component:");
client.ClientCode(simple);
Console.WriteLine();

/**
 * Instanciamos clases que hereden de PatronDecorator, que este a su vez, hereda de Component
 * Les podemos pasar por parametro tanto clases inferiores como Component, como mas superiores, PatronDecorator
 * Cuando llamemos a la funcion, se iran ejecutando las funciones de las instancias abstractas que recibimos.
 *
 */
ConcreteDecoratorA? decorator1 = new(simple);
ConcreteDecoratorB? decorator2 = new(decorator1);
Console.WriteLine("Client: Now I've got a decorated component:");
client.ClientCode(decorator2);

Console.ReadKey();
