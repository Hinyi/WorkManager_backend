using MediatR;

namespace IdentityService.Application.User.Command.RevokeToken;

public record RevokeTokenCommand(string refreshToken) : IRequest<RevokeTokenResponse>;