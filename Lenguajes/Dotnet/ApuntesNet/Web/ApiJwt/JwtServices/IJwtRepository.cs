namespace ApiJwt.JwtServices;

public interface IJwtRepository
{
    Task<bool> RemoveTokenByIdsAsync(int userId, string refreshTokenId);
    Task<string> CreateTokenAsync(int userId, DateTime expiration);
    Task<DateTime> GetTokenExpirationAsync(string refreshTokenId);
    Task<IEnumerable<JwtTokenData>> GetAllTokensByUserId(int userId);
}

public record JwtTokenData(Guid TokenId, DateTime Expiration);
