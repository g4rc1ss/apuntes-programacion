using System.Diagnostics;
using HttpClientVsHttpClientFactory;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection? services = new();
services.AddTransient<PruebaHttpClientFactory>();
services.AddTransient<PruebaUsingHttpClient>();
services.AddTransient<PruebaHttpClient>();
services.AddHttpClient();

await using ServiceProvider? serviceProvider = services.BuildServiceProvider();

string? endpoint = "https://jsonplaceholder.typicode.com/posts/1";

// Comprobar la IP, puede cambiar
string? ipEndpointToCheck = "172.64.164.25.443";
string? executeCommand = @$"-c ""netstat -an | awk '$5 == \""{ipEndpointToCheck}\""'""";

foreach (int item in Enumerable.Range(0, 10))
{
    PruebaHttpClientFactory? httpClientFactory =
        serviceProvider.GetRequiredService<PruebaHttpClientFactory>();
    await httpClientFactory.ExecutePruebaAsync(endpoint);
}
Console.WriteLine("HttpClientFactory");
Console.WriteLine(
    "------------------------------------------------------------------------------------"
);
Console.WriteLine($"{executeCommand}");
Process.Start("bash", executeCommand);
Console.WriteLine(
    "------------------------------------------------------------------------------------"
);

foreach (int item in Enumerable.Range(0, 10))
{
    PruebaUsingHttpClient? usingHttpClient =
        serviceProvider.GetRequiredService<PruebaUsingHttpClient>();
    await usingHttpClient.ExecutePruebaAsync(endpoint);
}
Console.WriteLine("Using HttpClient");
Console.WriteLine(
    "------------------------------------------------------------------------------------"
);
Console.WriteLine($"{executeCommand}");
Process.Start("bash", executeCommand);
Console.WriteLine(
    "------------------------------------------------------------------------------------"
);

foreach (int item in Enumerable.Range(0, 10))
{
    PruebaHttpClient? pruebaHttpClient = serviceProvider.GetRequiredService<PruebaHttpClient>();
    await pruebaHttpClient.ExecutePruebaAsync(endpoint);
}
Console.WriteLine("HttpClient In Ctor");
Console.WriteLine(
    "------------------------------------------------------------------------------------"
);
Console.WriteLine($"{executeCommand}");
Process.Start("bash", executeCommand);
Console.WriteLine(
    "------------------------------------------------------------------------------------"
);

Console.WriteLine("Finish");
