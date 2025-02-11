using AutoMapper;
using IdentityService.Interface;
using IdentityService.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IdentityService.Aplication.User.Command.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUser.CreateUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateUserCommandHandler> _logger;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<CreateUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger?? throw new ArgumentNullException(nameof(logger));
        
        // Console.WriteLine(logger != null ? "Logger Injected in CreateUserCommandHandler" : "Logger is NULL in CreateUserCommandHandler");
        //_logger.LogInformation("CreateUserCommandHandler initialized.");
    }

    public async Task<string> Handle(CreateUser.CreateUserCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating user with {@Request}", request);
        
        var passwordHash = PasswordHasher.GetHash(request.Password);
        
        var newUser = _mapper.Map<Entities.User>(request);
        newUser.PasswordHash = passwordHash;
        var id = newUser.Id;
        await _userRepository.AddUser(newUser);
        
        return id;
    }
}