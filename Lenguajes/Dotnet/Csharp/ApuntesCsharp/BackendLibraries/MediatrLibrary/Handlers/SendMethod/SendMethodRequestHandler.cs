using MediatR;

namespace MediatrLibrary.Handlers.SendMethod;

internal class SendMethodRequestHandler(IMediator mediator)
    : IRequestHandler<SendMethodRequest, SendMethodResponse>
{
    public Task<SendMethodResponse> Handle(
        SendMethodRequest request,
        CancellationToken cancellationToken
    )
    {
        Console.WriteLine($"El metodo SEND indica: {request.Message}");

        return Task.FromResult(new SendMethodResponse { Respuesta = "Tarea completada y eso" });
    }
}
