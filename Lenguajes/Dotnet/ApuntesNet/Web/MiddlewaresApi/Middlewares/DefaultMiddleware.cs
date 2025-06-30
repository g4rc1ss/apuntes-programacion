namespace MiddlewaresApi.Middlewares;

public class DefaultMiddleware(ILogger<DefaultMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Lo que se ejecuta antes de la resolucion de la request
        using MemoryStream? memoryStream = new();
        Stream? original = context.Response.Body;

        context.Response.Body = memoryStream;
        logger.LogInformation($"Request Path {context.Request.Path.Value}");

        // La llamada a la siguiente ejecucion correspondiente del Middleware hasta que se resuelva la Request
        await next(context);

        // Lo que se ejecuta despues de la resolucion de la request
        memoryStream.Seek(0, SeekOrigin.Begin);

        using StreamReader reader = new(context.Response.Body);
        string? data = await reader.ReadToEndAsync();
        memoryStream.Seek(0, SeekOrigin.Begin);

        logger.LogInformation($"Datos del Response {data}");
        await memoryStream.CopyToAsync(original);
        context.Response.Body = original;
    }
}
