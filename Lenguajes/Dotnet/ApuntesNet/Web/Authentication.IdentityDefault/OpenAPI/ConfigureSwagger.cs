using Microsoft.OpenApi.Models;

namespace Authentication.IdentityDefault.OpenAPI;

public static class ConfigureSwagger
{
    internal static void InitAndConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            OpenApiSecurityScheme securityScheme = new()
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Description = "JWT Authorization header (Bearer {token})",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            options.AddSecurityDefinition("Bearer", securityScheme);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                { securityScheme, Array.Empty<string>() }
            });

            // options.IncludeXmlComments(typeof(Program).Assembly);
        });
    }
}