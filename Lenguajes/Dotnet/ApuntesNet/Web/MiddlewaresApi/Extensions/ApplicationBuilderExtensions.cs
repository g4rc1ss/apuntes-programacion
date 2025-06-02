using MiddlewaresApi.Middlewares;

namespace MiddlewaresApi.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseError(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorMiddleware>();
        return app;
    }

    public static IApplicationBuilder UseDefault(this IApplicationBuilder app)
    {
        app.UseMiddleware<DefaultMiddleware>();
        return app;
    }
}
