namespace Mediator;

// The Base Component provides the basic functionality of storing a
// mediator's instance inside component objects.
internal class BaseComponent(IMediator mediator = null)
{
    protected IMediator mediator = mediator;

    public void SetMediator(IMediator mediator)
    {
        this.mediator = mediator;
    }
}
