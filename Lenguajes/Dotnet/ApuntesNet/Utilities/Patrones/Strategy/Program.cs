using Strategy;

// The client code picks a concrete strategy and passes it to the
// context. The client should be aware of the differences between
// strategies in order to make the right choice.
Context? context = new();

Console.WriteLine("Client: Strategy is set to normal sorting.");
context.SetStrategy(new ConcreteStrategyA());
context.DoSomeBusinessLogic();

Console.WriteLine();

Console.WriteLine("Client: Strategy is set to reverse sorting.");
context.SetStrategy(new ConcreteStrategyB());
context.DoSomeBusinessLogic();

Console.WriteLine("Pulsa una tecla para finalizar");
Console.ReadKey();
