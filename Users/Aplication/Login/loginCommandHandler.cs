using MediatR;
using Users.Interface;

namespace Users.Aplication.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return "placeHolder";
    }
}