using MiddlewaresApi.Extensions;
using MiddlewaresApi.Middlewares;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DefaultMiddleware>();
builder.Services.AddSingleton<ErrorMiddleware>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseError();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseDefault();
app.MapControllers();

app.Run();
