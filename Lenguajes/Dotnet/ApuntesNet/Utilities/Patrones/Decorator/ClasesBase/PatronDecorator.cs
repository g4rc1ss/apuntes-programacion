namespace Decorator.ClasesBase;

// The base Decorator class follows the same interface as the other
// components. The primary purpose of this class is to define the wrapping
// interface for all concrete decorators. The default implementation of the
// wrapping code might include a field for storing a wrapped component and
// the means to initialize it.
internal abstract class PatronDecorator(Component component) : Component
{
    protected Component component = component;

    public void SetComponent(Component component)
    {
        this.component = component;
    }

    // The Decorator delegates all work to the wrapped component.
    public override string Operation()
    {
        return component != null ? component.Operation() : string.Empty;
    }
}
