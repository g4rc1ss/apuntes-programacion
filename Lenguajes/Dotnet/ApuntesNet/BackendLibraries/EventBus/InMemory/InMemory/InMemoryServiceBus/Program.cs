using InMemoryServiceBus;
using InMemoryServiceBus.Workers;
using System.Threading.Channels;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();

BoundedChannelOptions channelOpts = new(100)
{
    FullMode = BoundedChannelFullMode.Wait
};
builder.Services.AddSingleton(Channel.CreateBounded<Dto>(channelOpts));

IHost host = builder.Build();

Channel<Dto> channel = host.Services.GetRequiredService<Channel<Dto>>();
await channel.Writer.WriteAsync(new Dto("Name 1", "Email1@example.com"));
await channel.Writer.WriteAsync(new Dto("Name 2", "Email2@example.com"));

await host.RunAsync();