using MediatR;

namespace IdentityService.Aplication.User.Command.RefreshToken;

public record RefreshTokenCommand(string refreshToken) : IRequest<RefreshTokenResponse>;