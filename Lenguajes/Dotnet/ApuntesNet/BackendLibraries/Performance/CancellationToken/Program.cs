WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseHttpsRedirection();

app.MapGet(
    "/",
    async (CancellationToken ct) =>
    {
        try
        {
            foreach (int i in Enumerable.Range(0, 1000))
            {
                Console.WriteLine($"iteration: {i}");

                await Task.Delay(i * 1000, ct); //this simulates a call to  a service
                Console.WriteLine("Completed;");
            }
        }
        catch (TaskCanceledException taskCanceledException)
        {
            Console.WriteLine(taskCanceledException);
            if (ct.IsCancellationRequested)
            {
                Console.WriteLine("Cancelled;");
            }
        }
    }
);

await app.RunAsync();
