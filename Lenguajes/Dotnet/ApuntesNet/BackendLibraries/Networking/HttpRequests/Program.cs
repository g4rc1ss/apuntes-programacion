using HttpRequests;
using HttpRequests.Internal;
using Microsoft.Extensions.DependencyInjection;

IServiceProvider? serviceProvider = HelperDi.GetServideProvider();

UsarHttpClient? usarHttpClient = serviceProvider.GetRequiredService<UsarHttpClient>();
await usarHttpClient.ExecuteHttpClientAsync();

Console.WriteLine("Pulsa un boton para terminar...");
Console.ReadKey();
