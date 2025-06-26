using ApiJwt.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiJwt.JwtServices;

public class JwtRepository(DatabaseDbContext dbContext) : IJwtRepository
{
    public async Task<bool> RemoveTokenByIdsAsync(int userId, string refreshTokenId)
    {
        UserJwtTokensEntity jwtEntity = new() { UserId = userId, Id = refreshTokenId };
        dbContext.UserJwtTokens.Remove(jwtEntity);
        return (await dbContext.SaveChangesAsync()) > 0;
    }

    public async Task<string> CreateTokenAsync(int userId, DateTime expiration)
    {
        UserJwtTokensEntity refreshTokenEntity = new()
        {
            UserId = userId,
            ExpirationUtc = expiration,
        };
        EntityEntry<UserJwtTokensEntity> entity = await dbContext.UserJwtTokens.AddAsync(
            refreshTokenEntity
        );
        await dbContext.SaveChangesAsync();

        return entity.Entity.Id;
    }

    public async Task<DateTime> GetTokenExpirationAsync(string refreshTokenId)
    {
        UserJwtTokensEntity refreshTokens = await dbContext.UserJwtTokens.SingleAsync(x =>
            x.Id == refreshTokenId
        );

        return refreshTokens.ExpirationUtc;
    }

    public async Task<IEnumerable<JwtTokenData>> GetAllTokensByUserId(int userId)
    {
        List<UserJwtTokensEntity> tokenList = await dbContext
            .UserJwtTokens.Where(x => x.UserId == userId && x.ExpirationUtc >= DateTime.UtcNow)
            .ToListAsync();

        return tokenList.Select(x => new JwtTokenData(Guid.Parse(x.Id), x.ExpirationUtc));
    }
}
