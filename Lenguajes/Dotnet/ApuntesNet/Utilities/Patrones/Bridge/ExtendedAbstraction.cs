using Bridge.Implementacion;

namespace Bridge;

// You can extend the Abstraction without changing the Implementation
// classes.
internal class ExtendedAbstraction(IImplementation implementation) : Abstraction(implementation)
{
    public override string Operation()
    {
        return "ExtendedAbstraction: Extended operation with:\n"
            + implementation.OperationImplementation();
    }
}
