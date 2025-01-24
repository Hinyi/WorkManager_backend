using AutoMapper;
using MediatR;
using Users.Interface;
using Users.Entities;

namespace Users.Aplication.User.Command.CreateUserCommand;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = _mapper.Map<Entities.User>(request);
        var id = newUser.Id;
        await _userRepository.AddUser(newUser);
        
        return id.ToString();
    }
}