using AutoMapper;
using IdentityService.Application.User.DTOs;
using IdentityService.Application.User.DTOs;
using IdentityService.Exceptions;
using IdentityService.Interface;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IdentityService.Application.User.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<GetUserByIdQueryHandler> _logger;

    public GetUserByIdQueryHandler(ILogger<GetUserByIdQueryHandler> logger, IUserRepository userRepository, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.Id, cancellationToken);
        if (user == null)
        {
            //_logger.LogWarning("User with id: {Id} was not found", request.Id);
            throw new UserNotFound(request.Id);
        }
        
        var result = _mapper.Map<UserDTO>(user);
        return result;
    }
}