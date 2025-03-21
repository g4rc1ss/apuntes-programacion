namespace MiddlewaresApi.Middlewares;

public class ErrorMiddleware(
    ILogger<ErrorMiddleware> logger
) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var messageResponse = new
            {
                Detalle = ex.Message,
                ex.StackTrace,
            };

            await context.Response.WriteAsJsonAsync(messageResponse);
        }
    }
}