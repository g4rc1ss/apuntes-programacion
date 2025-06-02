using Authentication.IdentityDefault;
using Authentication.IdentityDefault.Extensions;
using Authentication.IdentityDefault.OpenAPI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.InitAndConfigureSwagger();

builder.Services.AddAuthenticationProtocol(builder.Configuration);
builder.AddDatabase();

builder.Services.AddSingleton<IEmailSender<IdentityUser<int>>, EmailSender>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
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

app.MapGroup("auth").MapIdentityApi<IdentityUser<int>>();

app.MapGroup("authentication")
    .RequireAuthorization()
    .MapGet("/prueba-auth", () => Results.Ok("Hola"));

await app.RunAsync();
