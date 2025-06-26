namespace ApiJwt.JwtServices;

public record JwtOption
{
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public required string Key { get; init; }
    public required int ExpireSeconds { get; init; }
}
