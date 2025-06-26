namespace ChainOfResponsability;

internal class DogHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        return request.ToString() == "MeatBall"
            ? $"Dog: I'll eat the {request}.\n"
            : base.Handle(request);
    }
}
