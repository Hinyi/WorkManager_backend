using IdentityService.Authentication;
using IdentityService.Exceptions;
using IdentityService.Interface;
using IdentityService.Services;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace IdentityService.Application.User.Command.LoginUser;

internal sealed class LoginCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<LoginCommandHandler> _logger;
    private readonly IJwtProvider _jwtProvider;
    private readonly TokenSettings _tokenSettings;
    public LoginCommandHandler(IUserRepository userRepository, ILogger<LoginCommandHandler> logger, IJwtProvider jwtProvider, TokenSettings tokenSettings)
    {
        _userRepository = userRepository;
        _logger = logger;
        _jwtProvider = jwtProvider;
        _tokenSettings = tokenSettings;
    }
    
    public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(request.Email);
        if (user == null)
        {
            _logger.LogInformation("User not found");
            throw new UserNotFound();
        }
        if(!PasswordHasher.ValidatePassword(request.Password, user.PasswordHash))
        {
            _logger.LogInformation("Invalid password");
            throw new InvalidPassword();
        }
        
        var token = _jwtProvider.GenereateJwtToken(user);
        var refreshToken = _jwtProvider.GenerateRefreshToken();
        var expirationDate =  DateTime.UtcNow.AddMinutes(_tokenSettings.RefreshTokenExpiryTime);
        
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = expirationDate;
        
        await _userRepository.UpdateUser(user);
        
        return new LoginUserResponse(
            token,
            refreshToken,
            expirationDate
        );
    }
}