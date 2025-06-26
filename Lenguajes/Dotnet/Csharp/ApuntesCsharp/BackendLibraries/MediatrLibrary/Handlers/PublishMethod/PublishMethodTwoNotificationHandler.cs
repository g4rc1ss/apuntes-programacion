using MediatR;

namespace MediatrLibrary.Handlers.PublishMethod;

internal class PublishMethodTwoNotificationHandler(IServiceProvider serviceProvider)
    : INotificationHandler<PublishMethodRequest>
{
    public Task Handle(PublishMethodRequest notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"El metodo PUBLISH 2 indica: {notification.Message}");

        return Task.CompletedTask;
    }
}
