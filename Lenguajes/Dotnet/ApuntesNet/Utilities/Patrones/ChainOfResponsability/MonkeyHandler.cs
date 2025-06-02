namespace ChainOfResponsability;

internal class MonkeyHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        return (request as string) == "Banana"
            ? $"Monkey: I'll eat the {request}.\n"
            : base.Handle(request);
    }
}
