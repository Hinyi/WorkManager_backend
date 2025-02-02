using IdentityService.Interface;
using MediatR;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace IdentityService.Aplication.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<LoginCommandHandler> _logger;
    public LoginCommandHandler(IUserRepository userRepository, ILogger<LoginCommandHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }
    
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return "placeHolder";
    }
}