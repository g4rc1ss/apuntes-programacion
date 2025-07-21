using System;
using CreateDiscovery.Abstractions;

namespace CreateDiscovery.Sample;

[Discovery]
public class ExampleService : IExample
{
    public void Execute()
    {
        Console.WriteLine("Creating discovery generator");
    }
}

public interface IExample
{
    void Execute();
}
