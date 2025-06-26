namespace Command;

// However, some commands can delegate more complex operations to other
// objects, called "receivers."
internal class ComplexCommand(Receiver receiver, string a, string b) : ICommand
{
    // Commands can delegate to any methods of a receiver.

    public void Execute()
    {
        Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
        receiver.DoSomething(a);
        receiver.DoSomethingElse(b);
    }
}
