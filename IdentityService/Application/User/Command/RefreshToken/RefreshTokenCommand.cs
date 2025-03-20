using MediatR;

namespace IdentityService.Application.User.Command.RefreshToken;

public record RefreshTokenCommand(string refreshToken) : IRequest<RefreshTokenResponse>;