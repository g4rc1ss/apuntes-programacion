using Authentication.IdentityDefault.Extensions;
using Authentication.IdentityDefault.OpenAPI;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.InitAndConfigureSwagger();

builder.Services.AddAuthenticationProtocol(builder.Configuration);
builder.AddDatabase();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGroup("auth-manager")
    .MapIdentityApi<IdentityUser<int>>();

app.MapGet("/prueba-auth", () => Results.Ok("Hola"))
    .RequireAuthorization();

app.UseHttpsRedirection();

await app.RunAsync();