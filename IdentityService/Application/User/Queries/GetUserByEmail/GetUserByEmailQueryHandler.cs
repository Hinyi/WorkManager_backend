using AutoMapper;
using IdentityService.Application.User.DTOs;
using IdentityService.Application.User.DTOs;
using IdentityService.Exceptions;
using IdentityService.Interface;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IdentityService.Application.User.Queries.GetUserByEmail;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDTO>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<GetUserByEmailQueryHandler> _logger;

    public GetUserByEmailQueryHandler(
        IUserRepository userRepository, 
        IMapper mapper,
        ILogger<GetUserByEmailQueryHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UserDTO> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(request.email);
        if (user == null)
        {
            _logger.LogWarning("User with id: {email} was not found", request.email);
            throw new UserNotFound(request.email);
        }
        
        var result = _mapper.Map<UserDTO>(user);
        return result;
    }
}