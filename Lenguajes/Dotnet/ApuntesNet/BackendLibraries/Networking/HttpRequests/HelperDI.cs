using HttpRequests.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace HttpRequests;

internal class HelperDi
{
    internal static IServiceProvider GetServideProvider()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddTransient<MessageHandler>();
        services.AddTransient<UsarHttpClient>();

        services
            .AddHttpClient(
                "clientePrueba",
                (client) => client.BaseAddress = new Uri("https://pokeapi.co/api/v2/")
            )
            .AddHttpMessageHandler<MessageHandler>();

        return services.BuildServiceProvider();
    }
}
