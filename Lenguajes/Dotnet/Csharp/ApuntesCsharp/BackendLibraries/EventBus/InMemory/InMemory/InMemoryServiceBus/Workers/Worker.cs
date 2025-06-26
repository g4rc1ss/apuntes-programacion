using System.Threading.Channels;

namespace InMemoryServiceBus.Workers;

public class Worker(
    ILogger<Worker> logger,
    Channel<Dto> channel
) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await channel.Reader.WaitToReadAsync(stoppingToken))
        {
            while (channel.Reader.TryRead(out Dto? dto))
            {
                logger.LogInformation("{Name}, {Email}", dto.Name, dto.Email);
            }
        }
    }
}