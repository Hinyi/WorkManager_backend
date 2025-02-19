namespace IdentityService.Aplication.User.Command.LoginUser;

public record LoginUserResponse(string Token, string RefreshToken);