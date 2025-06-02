using TemplateMethod;

Console.WriteLine("Same client code can work with different subclasses:");

Client.ClientCode(new ConcreteClass1());

Console.Write("\n");

Console.WriteLine("Same client code can work with different subclasses:");
Client.ClientCode(new ConcreteClass2());

Console.WriteLine("Pulsa una tecla para finalizar");
Console.ReadKey();
