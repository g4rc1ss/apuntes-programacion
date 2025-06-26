using Visitor;

List<IComponent>? components = [new ConcreteComponentA(), new ConcreteComponentB()];

Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
ConcreteVisitor1? visitor1 = new();
Client.ClientCode(components, visitor1);

Console.WriteLine();

Console.WriteLine("It allows the same client code to work with different types of visitors:");
ConcreteVisitor2? visitor2 = new();
Client.ClientCode(components, visitor2);

Console.WriteLine("Pulsa una tecla para finalizar");
Console.ReadKey();
