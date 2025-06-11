namespace Mediator;

// Concrete Mediators implement cooperative behavior by coordinating several
// components.
internal class ConcreteMediator : IMediator
{
    private readonly Component1 _component1;

    private readonly Component2 _component2;

    public ConcreteMediator(Component1 component1, Component2 component2)
    {
        _component1 = component1;
        _component1.SetMediator(this);
        _component2 = component2;
        _component2.SetMediator(this);
    }

    public void Notify(object sender, string ev)
    {
        if (ev == "A")
        {
            Console.WriteLine("Mediator reacts on A and triggers folowing operations:");
            _component2.DoC();
        }
        if (ev == "D")
        {
            Console.WriteLine("Mediator reacts on D and triggers following operations:");
            _component1.DoB();
            _component2.DoC();
        }
    }
}
