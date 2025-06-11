using MediatR;

namespace MediatrLibrary.Handlers.PublishMethod;

internal class PublishMethodRequest : INotification
{
    public string? Message { get; set; }
}
