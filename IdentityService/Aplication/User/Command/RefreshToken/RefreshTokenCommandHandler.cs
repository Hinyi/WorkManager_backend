using IdentityService.Authentication;
using IdentityService.Exceptions;
using IdentityService.Interface;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;

namespace IdentityService.Aplication.User.Command.RefreshToken;

/// <summary>
/// Endpoint for refreshing the token
/// </summary>
/// <param name=""></param>
/// <returns>returns new token and refreshed token</returns>

internal sealed class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<RefreshTokenCommandHandler> _logger;
    private readonly IJwtProvider _jwtProvider;
    public RefreshTokenCommandHandler(IUserRepository userRepository, ILogger<RefreshTokenCommandHandler> logger, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _logger = logger;
        _jwtProvider = jwtProvider;
    }
    public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByRefreshToken(request.refreshToken, cancellationToken);
        
        if(user is null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
        {
            _logger.LogInformation("Invalid or expired refresh token");
            throw new Unauthorized("Invalid or expired refresh token");
        }
        
        var token = _jwtProvider.GenereateJwtToken(user);
        var refreshToken = _jwtProvider.GenerateRefreshToken();
        
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(5);
        
        await _userRepository.UpdateUser(user);
        
        return new RefreshTokenResponse(token, refreshToken);
    }
}