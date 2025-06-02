namespace Command;

// Some commands can implement simple operations on their own.
internal class SimpleCommand(string payload) : ICommand
{
    public void Execute()
    {
        Console.WriteLine($"SimpleCommand: See, I can do simple things like printing ({payload})");
    }
}
