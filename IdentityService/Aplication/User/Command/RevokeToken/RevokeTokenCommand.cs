using MediatR;

namespace IdentityService.Aplication.User.Command.RevokeToken;

public record RevokeTokenCommand(string refreshToken) : IRequest;