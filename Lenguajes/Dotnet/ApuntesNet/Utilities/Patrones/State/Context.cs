namespace State;

// The Context defines the interface of interest to clients. It also
// maintains a reference to an instance of a State subclass, which
// represents the current state of the Context.
internal class Context
{
    // A reference to the current state of the Context.
    private State state = null;

    public Context(State state)
    {
        TransitionTo(state);
    }

    // The Context allows changing the State object at runtime.
    public void TransitionTo(State state)
    {
        Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
        this.state = state;
        this.state.SetContext(this);
    }

    // The Context delegates part of its behavior to the current State
    // object.
    public void Request1()
    {
        state.Handle1();
    }

    public void Request2()
    {
        state.Handle2();
    }
}
