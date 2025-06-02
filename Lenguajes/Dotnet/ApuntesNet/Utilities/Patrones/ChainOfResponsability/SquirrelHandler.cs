namespace ChainOfResponsability;

internal class SquirrelHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        return request.ToString() == "Nut"
            ? $"Squirrel: I'll eat the {request}.\n"
            : base.Handle(request);
    }
}
