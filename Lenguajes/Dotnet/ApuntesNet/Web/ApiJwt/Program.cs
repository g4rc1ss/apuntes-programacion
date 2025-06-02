using System.Security.Claims;
using ApiJwt;
using ApiJwt.Extensions;
using ApiJwt.JwtServices;
using ApiJwt.OpenAPI;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.InitAndConfigureSwagger();

builder.Services.AddAuthenticationProtocol(builder.Configuration);
builder.Services.AddScoped<IJwtRepository, JwtRepository>();
builder.Services.AddScoped<IJwtTokenManagement, JwtTokenManagement>();

builder.AddDatabase();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (IServiceScope scope = app.Services.CreateScope())
{
    DatabaseDbContext context = scope.ServiceProvider.GetRequiredService<DatabaseDbContext>();
    await context.Database.MigrateAsync();
}

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet(
    "create-jwt",
    async (IJwtTokenManagement jwtTokenManagement) =>
    {
        string refresh = await jwtTokenManagement.CreateRefreshTokenAsync(1);
        IEnumerable<Claim> claims = [new(ClaimTypes.Role, "Admin")];
        string jwt = jwtTokenManagement.Create(new("1", "username", "email", refresh, claims));

        return jwt;
    }
);

app.MapPost(
    "refresh-jwt",
    (IJwtTokenManagement jwtTokenManagement, string accesstoken) =>
    {
        return jwtTokenManagement.Refresh(accesstoken);
    }
);

app.MapPost(
        "revoke-jwt/{userId}",
        async (IJwtTokenManagement jwtTokenManagement, string refreshTokenId, string userId) =>
        {
            await jwtTokenManagement.RevokeRefreshTokenAsync(int.Parse(userId), refreshTokenId);
        }
    )
    .RequireAuthorization();

app.MapGet(
        "list-jwt",
        async (IJwtRepository JwtRepository, string userId) =>
        {
            IEnumerable<JwtTokenData> jwt = await JwtRepository.GetAllTokensByUserId(
                int.Parse(userId)
            );
            return jwt;
        }
    )
    .RequireAuthorization();

app.MapGet("prueba", () => Results.Ok("OK")).RequireAuthorization();

await app.RunAsync();
