using System.Text;
using ApiJwt.JwtServices;
using Microsoft.IdentityModel.Tokens;

namespace ApiJwt.Extensions;

internal static class AuthenticationExtensions
{
    internal static void AddAuthenticationProtocol(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddHttpContextAccessor()
            .AddAuthorization()
            .AddAuthentication(options => { })
            .AddJwtBearer(options =>
            {
                IConfigurationSection jwtOptionsSection = configuration.GetSection("Jwt");

                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime = true,
                    ValidIssuer = jwtOptionsSection["Issuer"],
                    ValidAudience = jwtOptionsSection["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptionsSection["Key"]!)
                    ),
                };
            });

        services.AddOptions();
        services.Configure<JwtOption>(configuration.GetSection("Jwt"));
    }
}
