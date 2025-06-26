// The client code.
using Observer;

Subject? subject = new();
ConcreteObserverA? observerA = new();
subject.Attach(observerA);

ConcreteObserverB? observerB = new();
subject.Attach(observerB);

subject.SomeBusinessLogic();
subject.SomeBusinessLogic();

subject.Detach(observerB);

subject.SomeBusinessLogic();

Console.WriteLine("Pulsa una tecla para finalizar");
Console.ReadKey();
