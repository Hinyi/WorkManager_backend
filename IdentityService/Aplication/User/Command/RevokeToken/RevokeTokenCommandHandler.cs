using IdentityService.Aplication.User.Command.RefreshToken;
using IdentityService.Authentication;
using IdentityService.Exceptions;
using IdentityService.Interface;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IdentityService.Aplication.User.Command.RevokeToken;

public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<RevokeTokenCommandHandler> _logger;
    private readonly IJwtProvider _jwtProvider;

    public RevokeTokenCommandHandler(IUserRepository userRepository, ILogger<RevokeTokenCommandHandler> logger, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _logger = logger;
        _jwtProvider = jwtProvider;
    }

    public async Task<string> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByRefreshToken(request.refreshToken, cancellationToken);
        
        if(user is null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
        {
            _logger.LogInformation("Invalid or expired refresh token");
            throw new Unauthorized("Invalid or expired refresh token");
        }
        
        user.RefreshToken = null;
        user.RefreshTokenExpiryTime = DateTime.Now;
        
        await _userRepository.UpdateUser(user);
        
        return "Token revoked successfully";
    }
}