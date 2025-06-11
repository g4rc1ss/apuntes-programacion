using MediatR;

namespace MediatrLibrary.Handlers.SendMethod;

internal class SendMethodRequest : IRequest<SendMethodResponse>
{
    public string? Message { get; set; }
}
