using System.Security.Claims;

namespace ApiJwt.JwtServices;

public interface IJwtTokenManagement
{
    IEnumerable<Claim> ReadClaims(string accessToken = "");
    string Create(JwtData jwtData);
    string Refresh(string accessToken = "");
    Task<string> CreateRefreshTokenAsync(int userId);
    Task<bool> RevokeRefreshTokenAsync(int userId, string refreshTokenId);
}

public record JwtData(
    string UserId,
    string UserName,
    string UserEmail,
    string RefreshToken,
    IEnumerable<Claim>? AdditionalClaims
);
