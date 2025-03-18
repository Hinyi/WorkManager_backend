using IdentityService.Aplication.User.DTOs;
using IdentityService.Exceptions;
using IdentityService.Interface;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IdentityService.Aplication.User.Command.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDTO>
{
    private readonly ILogger<UpdateUserCommandHandler> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IUserMapper _userMapper;

    public UpdateUserCommandHandler(ILogger<UpdateUserCommandHandler> logger, IUserRepository userRepository, IUserMapper userMapper)
    {
        _logger = logger;
        _userRepository = userRepository;
        _userMapper = userMapper;
    }


    public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.userId, cancellationToken);

        if (user == null)
        {
            _logger.LogError("User not found");
            throw new UserNotFound(nameof(User), request.userId);
        }

        user.UserName = request.username;
        
        
        await _userRepository.UpdateUser(user);

        var userResponse = _userMapper.MapToUserDto(user);
        
        return userResponse;
    }
}