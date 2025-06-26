namespace ApiJwt.Entities;

public class UserJwtTokensEntity
{
    public string Id { get; set; }
    public int UserId { get; set; }
    public DateTime ExpirationUtc { get; set; }
}
