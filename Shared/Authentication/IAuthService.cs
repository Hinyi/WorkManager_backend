namespace Shared.Authentication;

public interface IAuthService
{
    Task<TokenResponse> GenerateTokenAsync(string username, string[] roles);
    Task<TokenResponse> RefreshTokenAsync(string refreshToken);
    Task<bool> ValidateTokenAsync(string token);
    Task RevokeTokenAsync(string username);
}