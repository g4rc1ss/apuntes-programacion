namespace Command;

// The Invoker is associated with one or several commands. It sends a
// request to the command.
internal class Invoker
{
    private readonly Queue<ICommand> _queue = new();

    public void Add(ICommand command)
    {
        _queue.Enqueue(command);
    }

    public void Execute()
    {
        foreach (ICommand? item in _queue)
        {
            item.Execute();
        }
    }
}
