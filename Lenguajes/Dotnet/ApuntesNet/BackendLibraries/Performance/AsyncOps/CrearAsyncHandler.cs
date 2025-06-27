using System.Runtime.CompilerServices;

namespace AsyncOps;

public class CustomTask : INotifyCompletion
{
    public void OnCompleted(Action continuation)
    {
        // this.IsCompleted = true;
        if (IsCompleted)
        {
            continuation?.Invoke();
        }
    }

    public bool IsCompleted { get; private set; }

    public void GetResult()
    {
        Console.WriteLine("Devolvemos el resultado de la operacion");
    }

    public CustomTask GetAwaiter()
    {
        Console.WriteLine("Donde Ejecutamos la operacion async");
        // Foo itself is the awaitable.
        return this;
    }
}
