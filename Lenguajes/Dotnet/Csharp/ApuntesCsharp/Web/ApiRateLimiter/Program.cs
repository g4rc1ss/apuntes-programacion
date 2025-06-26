using System.Text.Json;
using System.Threading.RateLimiting;
using ApiRateLimiter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Agregamos rate limit de concurrencia
// Creamos el límite de 10 llamadas
// Con una cola de 100 en espera max
// Vamos procesando primero las antiguas a más nuevas
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = 429; // Too many request
    options.OnRejected = async (context, token) =>
    {
        ProblemDetails details = new()
        {
            Status = StatusCodes.Status429TooManyRequests,
            Title = "Too many requests",
            Detail = "Please try again later.",
        };
        await context.HttpContext.Response.WriteAsync(JsonSerializer.Serialize(details));
    };
    options.AddConcurrencyLimiter(
        policyName: "concurrency-policy",
        limiterOptions =>
        {
            limiterOptions.PermitLimit = 10;
            limiterOptions.QueueLimit = 100;
            limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        }
    );
});

// Agregamos rate limit de Tokens
// Agregamos un límite de tokens asociados al cliente y generamos 2 cada 5 minutos
// Cuando se llega al límite, se rechazan todas
builder.Services.AddRateLimiter(options =>
{
    options.AddTokenBucketLimiter(
        policyName: "token-limiter",
        limiterOptions =>
        {
            limiterOptions.TokensPerPeriod = 2;
            limiterOptions.TokenLimit = 100;
            limiterOptions.ReplenishmentPeriod = TimeSpan.FromMinutes(5);
        }
    );
});

// Agregamos rate limit de ventana fija
// Vamos a permitir solo 2 peticiones por ventana
// La ventana dura 5 minutos
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter(
        policyName: "window-fixed-limiter",
        limiterOptions =>
        {
            limiterOptions.PermitLimit = 2;
            limiterOptions.QueueLimit = 100;
            limiterOptions.Window = TimeSpan.FromMinutes(5);
        }
    );
});

// Agregamos rate limit de ventana deslizante
// Vamos a permitir 5 llamadas por ventana y cada ventana dura 5 minutos
// Vamos a asignar segmentos a la ventana, en este caso 5
// Vamos a permitir un maximo de 1 llamada por minuto
builder.Services.AddRateLimiter(options =>
{
    options.AddSlidingWindowLimiter(
        policyName: "window-sliding-limiter",
        limiterOptions =>
        {
            limiterOptions.PermitLimit = 5;
            limiterOptions.QueueLimit = 100;
            limiterOptions.SegmentsPerWindow = 5;
            limiterOptions.Window = TimeSpan.FromMinutes(5);
        }
    );
});

// Para crear una regla personalizada

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
}

app.UseRateLimiter();
app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");
app.MapGet("/concurrency", () => "Hello World!").RequireRateLimiting("concurrency-policy");

app.MapGet("/token", () => "Hello World!").RequireRateLimiting("token-limiter");

app.MapGet("/fixedWindow", () => "Hello World!").RequireRateLimiting("window-fixed-limiter");

app.MapGet("/slidingWindow", () => "Hello World!").RequireRateLimiting("window-sliding-limiter");

app.MapGet("/personalized", () => "Hello World!").RequireRateLimiting(new RateLimitierPolicy());

await app.RunAsync();
