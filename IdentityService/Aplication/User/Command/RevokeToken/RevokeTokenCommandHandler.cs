using MediatR;

namespace IdentityService.Aplication.User.Command.RevokeToken;

public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand>
{
    public async Task Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}