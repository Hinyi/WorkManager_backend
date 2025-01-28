using AutoMapper;
using IdentityService.Interface;
using MediatR;
using IdentityService.Entities;
using Microsoft.Extensions.Logging;

namespace IdentityService.Aplication.User.Command.CreateUserCommand;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<CreateUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating user with {@Request}", request);
        var newUser = _mapper.Map<Entities.User>(request);
        var id = newUser.Id;
        await _userRepository.AddUser(newUser);
        
        return id.ToString();
    }
}