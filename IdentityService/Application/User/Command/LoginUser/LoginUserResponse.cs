namespace IdentityService.Application.User.Command.LoginUser;

public record LoginUserResponse(string Token, string RefreshToken);