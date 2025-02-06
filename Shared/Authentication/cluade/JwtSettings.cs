namespace Shared.Authentication;

public class JwtSettings1
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string SecretKey { get; init; }
}