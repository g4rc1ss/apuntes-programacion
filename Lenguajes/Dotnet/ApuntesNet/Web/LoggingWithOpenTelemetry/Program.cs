using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Events;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder
    .Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService(builder.Configuration["AppName"]!))
    .WithTracing(trace =>
    {
        trace.AddAspNetCoreInstrumentation();
        trace.AddHttpClientInstrumentation();
        // trace.AddSource("MongoDB.Driver.Core.Extensions.DiagnosticSources");
        // trace.AddSource(nameof(IDistributedCache));
        trace.AddOtlpExporter(exporter =>
            exporter.Endpoint = new Uri(builder.Configuration["ConnectionStrings:OpenTelemetry"]!)
        );
    })
    .WithMetrics(metric =>
    {
        metric.AddMeter("HostWebApi");
        metric.AddAspNetCoreInstrumentation();
        metric.AddRuntimeInstrumentation();
        metric.AddHttpClientInstrumentation();
        metric.AddProcessInstrumentation();

        metric.AddOtlpExporter(exporter =>
        {
            exporter.Endpoint = new Uri(builder.Configuration["ConnectionStrings:OpenTelemetry"]!);
            exporter.Protocol = OtlpExportProtocol.Grpc;
        });
    });

builder.Host.UseSerilog(
    (context, loggerConfiguration) =>
    {
        loggerConfiguration
            .MinimumLevel.Information()
            .Enrich.WithProperty("Application", "HostWebApi")
            .WriteTo.OpenTelemetry(options =>
                options.Endpoint = builder.Configuration["ConnectionStrings:OpenTelemetry"]!
            );

        if (context.HostingEnvironment.IsDevelopment())
        {
            loggerConfiguration.WriteTo.Console(LogEventLevel.Debug);
        }
    }
);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet(
    "/",
    (ILogger<Program> logger) =>
    {
        logger.LogInformation("Hello World!");

        return Results.Ok();
    }
);

await app.RunAsync();
