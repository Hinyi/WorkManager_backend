namespace Shared.Authentication;

public class JwtSettings
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string SecretKey { get; init; }
    public string Authority { get; init; }
    
}