using Bridge.Implementacion;

namespace Bridge;

// The Abstraction defines the interface for the "control" part of the two
// class hierarchies. It maintains a reference to an object of the
// Implementation hierarchy and delegates all of the real work to this
// object.
internal class Abstraction(IImplementation implementation)
{
    protected IImplementation implementation = implementation;

    public virtual string Operation()
    {
        return "Abstract: Base operation with:\n" + implementation.OperationImplementation();
    }
}
