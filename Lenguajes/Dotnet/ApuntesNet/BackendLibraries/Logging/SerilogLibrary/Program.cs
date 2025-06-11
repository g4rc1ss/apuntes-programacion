using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SerilogLibrary;

IServiceProvider? serviceProvider = Helper.GetServiceProvider();
ILogger<Program>? logger = serviceProvider.GetRequiredService<ILogger<Program>>();

UserDTO? user = new()
{
    Name = "Prueba",
    SurName = "Logger",
    Email = "Prueba@logger.com",
    MerchantId = "1234567890",
    TerminalId = "0000000001",
};
logger.LogTrace("Log para traza con informacion generalmente con informacion sensible");
logger.LogDebug(
    "Log para informacion mas centrada en la Depuracion, por ejemplo, {@estadoDeThreads}",
    Process.GetCurrentProcess().Threads
);
logger.LogInformation("Datos de usuario {@DatosCreacionUsuario}", user);
logger.LogWarning("Log para trazas importantes, por ejemplo fallos en un proceso de negocio");
logger.LogError("Log para errores, como excepciones normales controladas");
logger.LogCritical(
    "Log generalmente para excepciones no controladas y errores que puedes desestabilizar el sistema"
);

Console.Read();
