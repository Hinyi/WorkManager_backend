using MediatR;

namespace IdentityService.Aplication.User.Command.RefreshToken;

public class RefreshTokenCommandHandler() : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
{
    public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}