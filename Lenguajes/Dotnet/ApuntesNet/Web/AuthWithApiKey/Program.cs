using AuthWithApiKey;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DisposableObject>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer(
        (document, _, _) =>
        {
            Dictionary<string, OpenApiSecurityScheme> requirements = new()
            {
                ["Bearer"] = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    In = ParameterLocation.Header,
                    BearerFormat = "Json Web Token",
                },
                [Constants.API_KEY_SCHEME] = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = Constants.API_KEY_HEADER_NAME,
                    In = ParameterLocation.Header,
                    Description = "API Key",
                },
            };
            document.Components ??= new OpenApiComponents();
            document.Components.SecuritySchemes = requirements;

            return Task.CompletedTask;
        }
    );
});

builder
    .Services.AddAuthorization()
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = Constants.API_KEY_SCHEME;
        options.DefaultChallengeScheme = Constants.API_KEY_SCHEME;
    })
    .AddScheme<ApiKeyAuthOptions, ApiKeyAuthHandler>(Constants.API_KEY_SCHEME, options => { });

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(
        "api-doc",
        options =>
        {
            options.AddPreferredSecuritySchemes(Constants.API_KEY_SCHEME);
        }
    );
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!").RequireAuthorization();

app.MapGet(
    "/disposable",
    async (DisposableObject disposable) =>
    {
        await disposable.client.GetAsync("https://google.es");
        Console.WriteLine("Ejecutando el endpoint");
    }
);

app.Run();
