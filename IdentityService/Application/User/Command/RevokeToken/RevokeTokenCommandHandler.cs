using IdentityService.Application.User.Command.RefreshToken;
using IdentityService.Authentication;
using IdentityService.Exceptions;
using IdentityService.Interface;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IdentityService.Application.User.Command.RevokeToken;

public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, RevokeTokenResponse>
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

    public async Task<RevokeTokenResponse> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByRefreshToken(request.refreshToken, cancellationToken);
        
        if(user is null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
        {
            _logger.LogInformation("Invalid or expired refresh token");
            throw new Unauthorized("Invalid or expired refresh token");
        }
        
        user.RefreshToken = null;
        user.RefreshTokenExpiryTime = DateTime.UtcNow;
        
        await _userRepository.UpdateUser(user);
        
        return new RevokeTokenResponse("Token revoked successfully");
    }
}