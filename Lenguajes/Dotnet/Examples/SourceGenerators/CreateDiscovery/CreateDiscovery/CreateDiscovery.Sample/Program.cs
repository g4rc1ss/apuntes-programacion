using CreateDiscovery.Sample;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new();

// services.AddDependencies();

await using ServiceProvider provider = services.BuildServiceProvider();
provider.GetRequiredService<IExample>();
