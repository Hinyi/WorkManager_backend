using AutoMapper;
using IdentityService.Application.User.Command.CreateUser;
using IdentityService.Exceptions;
using IdentityService.Interface;
using IdentityService.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Enum;

namespace IdentityService.Application.User.Command.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateUserCommandHandler> _logger;
    // private readonly IPublishEndpoint _publishEndpoint;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<CreateUserCommandHandler> logger)//, IPublishEndpoint publishEndpoint)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger?? throw new ArgumentNullException(nameof(logger));
        //_publishEndpoint = publishEndpoint;

        // Console.WriteLine(logger != null ? "Logger Injected in CreateUserCommandHandler" : "Logger is NULL in CreateUserCommandHandler");
        //_logger.LogInformation("CreateUserCommandHandler initialized.");
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating user with {@Request}", request);


        if (!await _userRepository.IsEmailUnique(request.Email, cancellationToken))
        {
            _logger.LogInformation("User with this email already exist");
            throw new UserAlreadyExistExceptions("User with this email already exist");
        }
            
        var passwordHash = PasswordHasher.GetHash(request.Password);
        
        var newUser = _mapper.Map<Entities.User>(request);
        newUser.PasswordHash = passwordHash;
        var id = newUser.Id;
        newUser.Role = Roles.User.ToString();
        await _userRepository.AddUser(newUser);
        
        // await _publishEndpoint.Publish(new UserCreatedEvent
        // {
        //     Id = newUser.Id,
        //     CreatedOnUtc = DateTime.UtcNow,
        //     
        // }, cancellationToken);
        
        return id;
    }
}