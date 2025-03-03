﻿namespace Memento;

// The Originator holds some important state that may change over time. It
// also defines a method for saving the state inside a memento and another
// method for restoring the state from it.
internal class Originator
{
    // For the sake of simplicity, the originator's state is stored inside a
    // single variable.
    private string state;

    public Originator(string state)
    {
        this.state = state;
        Console.WriteLine("Originator: My initial state is: " + state);
    }

    // The Originator's business logic may affect its internal state.
    // Therefore, the client should backup the state before launching
    // methods of the business logic via the save() method.
    public void DoSomething()
    {
        Console.WriteLine("Originator: I'm doing something important.");
        state = GenerateRandomString(30);
        Console.WriteLine($"Originator: and my state has changed to: {state}");
    }

    private string GenerateRandomString(int length = 10)
    {
        string? allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string? result = string.Empty;

        while (length > 0)
        {
            result += allowedSymbols[new Random().Next(0, allowedSymbols.Length)];

            Thread.Sleep(12);

            length--;
        }

        return result;
    }

    // Saves the current state inside a memento.
    public IMemento Save()
    {
        return new ConcreteMemento(state);
    }

    // Restores the Originator's state from a memento object.
    public void Restore(IMemento memento)
    {
        if (memento is not ConcreteMemento)
        {
            throw new Exception("Unknown memento class " + memento.ToString());
        }

        state = memento.GetState();
        Console.Write($"Originator: My state has changed to: {state}");
    }
}
