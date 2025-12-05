using IdentityService.Authentication;
using IdentityService.Exceptions;
using IdentityService.Interface;
using IdentityService.Services;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IdentityService.Application.User.Command.RefreshToken;

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
    private readonly TokenSettings _tokenSettings;
    
    public RefreshTokenCommandHandler(
        IUserRepository userRepository, 
        ILogger<RefreshTokenCommandHandler> logger, 
        IJwtProvider jwtProvider, 
        IOptions<TokenSettings> tokenSettings)
    {
        _userRepository = userRepository;
        _logger = logger;
        _jwtProvider = jwtProvider;
        _tokenSettings = tokenSettings.Value;
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
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(_tokenSettings.RefreshTokenExpiryTime);
        
        
        await _userRepository.UpdateUser(user);
        
        return new RefreshTokenResponse(token, refreshToken);
    }
}