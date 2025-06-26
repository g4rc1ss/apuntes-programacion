using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace AuthWithApiKey;

internal class ApiKeyAuthOptions : AuthenticationSchemeOptions;

internal class ApiKeyAuthHandler(
    IOptionsMonitor<ApiKeyAuthOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder,
    IConfiguration configuration
) : AuthenticationHandler<ApiKeyAuthOptions>(options, logger, encoder)
{
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            if (Context?.GetEndpoint()?.Metadata.GetMetadata<IAuthorizeData>() is not null)
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            if (
                !Request.Headers.TryGetValue(
                    Constants.API_KEY_HEADER_NAME,
                    out StringValues headerApiKey
                )
            )
            {
                return Task.FromResult(AuthenticateResult.Fail("No api key provided"));
            }

            string? apiKey = configuration["ApiKey"];

            if (apiKey != headerApiKey)
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid api key"));
            }

            ClaimsIdentity identity = new([], Scheme.Name);
            AuthenticationTicket ticket = new(new ClaimsPrincipal(identity), Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
        catch (Exception e)
        {
            return Task.FromResult(AuthenticateResult.Fail(e));
        }
    }
}
