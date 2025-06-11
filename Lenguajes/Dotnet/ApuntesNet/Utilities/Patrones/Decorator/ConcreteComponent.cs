using Decorator.ClasesBase;

namespace Decorator;

// Concrete Components provide default implementations of the operations.
// There might be several variations of these classes.
internal sealed class ConcreteComponent : Component
{
    public override string Operation()
    {
        return "ConcreteComponent";
    }
}
