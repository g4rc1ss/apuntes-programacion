using Decorator.ClasesBase;

namespace Decorator;

// Concrete Decorators call the wrapped object and alter its result in some
// way.
internal sealed class ConcreteDecoratorA(Component comp) : PatronDecorator(comp)
{
    // Decorators may call parent implementation of the operation, instead
    // of calling the wrapped object directly. This approach simplifies
    // extension of decorator classes.
    public override string Operation()
    {
        return $"ConcreteDecoratorA({base.Operation()})";
    }
}
