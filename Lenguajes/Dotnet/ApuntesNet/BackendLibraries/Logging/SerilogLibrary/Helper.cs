using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace SerilogLibrary;

public class Helper
{
    public static IServiceProvider GetServiceProvider()
    {
        IHostBuilder? builder = Host.CreateDefaultBuilder();

        builder.ConfigureLogging(log =>
        {
            log.ClearProviders();
            log.AddConsole();
            log.SetMinimumLevel(LogLevel.Trace);
        });
        builder.UseSerilog(
            (hostContext, loggerConfig) =>
            {
                loggerConfig.WriteTo.Seq(
                    hostContext.Configuration["ConnectionStrings:SeqConnectionString"]!
                );
                loggerConfig.WriteTo.Console();
            }
        );

        IHost? app = builder.Build();

        return app.Services;
    }
}
