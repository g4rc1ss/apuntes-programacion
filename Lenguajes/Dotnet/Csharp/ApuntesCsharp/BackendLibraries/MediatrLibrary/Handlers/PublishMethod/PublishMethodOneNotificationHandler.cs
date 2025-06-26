using MediatR;

namespace MediatrLibrary.Handlers.PublishMethod;

internal class PublishMethodOneNotificationHandler : INotificationHandler<PublishMethodRequest>
{
    public Task Handle(PublishMethodRequest notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"El metodo PUBLISH 1 indica: {notification.Message}");

        return Task.CompletedTask;
    }
}
