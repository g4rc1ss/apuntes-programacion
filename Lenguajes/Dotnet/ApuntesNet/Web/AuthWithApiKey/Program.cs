using AuthWithApiKey;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAuthorization()
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = Constants.API_KEY_SCHEME;
        options.DefaultChallengeScheme = Constants.API_KEY_SCHEME;
    }).AddScheme<ApiKeyAuthOptions, ApiKeyAuthHandler>(Constants.API_KEY_SCHEME, options => { });

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/", () => "Hello World!")
    .RequireAuthorization();
app.Run();