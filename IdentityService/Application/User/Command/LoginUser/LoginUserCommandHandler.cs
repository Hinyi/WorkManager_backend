using IdentityService.Authentication;
using IdentityService.Exceptions;
using IdentityService.Interface;
using IdentityService.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IdentityService.Application.User.Command.LoginUser;

internal sealed class LoginCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<LoginCommandHandler> _logger;
    private readonly IJwtProvider _jwtProvider;
    public LoginCommandHandler(IUserRepository userRepository, ILogger<LoginCommandHandler> logger, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _logger = logger;
        _jwtProvider = jwtProvider;
    }
    
    public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(request.Email);
        if (user == null)
        {
            _logger.LogInformation("User not found");
            throw new UserNotFound();
        }
        if(!PasswordHasher.ValidatePassword(request.password, user.PasswordHash))
        {
            _logger.LogInformation("Invalid password");
            throw new InvalidPassword();
        }
        
        var token = _jwtProvider.GenereateJwtToken(user);
        var refreshToken = _jwtProvider.GenerateRefreshToken();
        
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(60);
        
        await _userRepository.UpdateUser(user);
        
        return new LoginUserResponse(
            token,
            refreshToken
        );
    }
}