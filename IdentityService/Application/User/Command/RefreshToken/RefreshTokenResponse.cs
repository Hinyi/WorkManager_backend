namespace IdentityService.Application.User.Command.RefreshToken;

public record RefreshTokenResponse(string token, string refreshToken)
{

}