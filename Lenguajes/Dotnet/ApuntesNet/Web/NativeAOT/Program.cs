using System.Reflection.Emit;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

WebApplication app = builder.Build();

Todo[] sampleTodos =
[
    new(1, "Walk the dog"),
    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Clean the bathroom"),
    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2))),
];

RouteGroupBuilder todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet(
    "/{id}",
    (int id) =>
        sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
            ? Results.Ok(todo)
            : Results.NotFound()
);

todosApi.MapGet("/reflection", () =>
{
    // Fallara por crear codigo en tiempo de ejecución

    var method = new DynamicMethod(
        "Sum",
        typeof(int),
        new Type[] { typeof(int), typeof(int) },
        typeof(Program).Module);

    ILGenerator il = method.GetILGenerator();
    il.Emit(OpCodes.Ldarg_0); // Carga el primer parámetro
    il.Emit(OpCodes.Ldarg_1); // Carga el segundo parámetro
    il.Emit(OpCodes.Add); // Suma
    il.Emit(OpCodes.Ret); // Retorna el resultado

    var sum = (SumDelegate)method.CreateDelegate(typeof(SumDelegate));
    Console.WriteLine(sum(5, 3)); // Output: 8
});

app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}

public delegate int SumDelegate(int a, int b);