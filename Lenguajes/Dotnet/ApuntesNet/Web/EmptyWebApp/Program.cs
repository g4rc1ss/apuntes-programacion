WebApplicationOptions options = new()
{
    ApplicationName = "EmptyWebApp",
    Args = args,
    EnvironmentName = "Development",
};

WebApplicationBuilder builder = WebApplication.CreateEmptyBuilder(options);

builder.WebHost.UseKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(7011);
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddRouting();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

string[] summaries =
[
    "Freezing",
    "Bracing",
    "Chilly",
    "Cool",
    "Mild",
    "Warm",
    "Balmy",
    "Hot",
    "Sweltering",
    "Scorching",
];

app.MapGet(
        "/weatherforecast",
        () =>
        {
            WeatherForecast[] forecast =
            [
                .. Enumerable
                    .Range(1, 5)
                    .Select(index => new WeatherForecast(
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    )),
            ];
            return forecast;
        }
    )
    .WithName("GetWeatherForecast");

await app.RunAsync();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
