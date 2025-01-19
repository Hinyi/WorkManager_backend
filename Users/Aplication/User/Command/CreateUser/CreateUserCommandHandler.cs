using AutoMapper;
using MediatR;
using Users.Interface;
using Users.Entities;

namespace Users.Aplication.User.Command.CreateUserCommand;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = _mapper.Map<Entities.User>(request);
        await _userRepository.AddUser(newUser);
    }
}