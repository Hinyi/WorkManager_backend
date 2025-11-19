using AutoMapper;
using IdentityService.Application.User.DTOs;
using IdentityService.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Application.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
{
    private readonly IMapper _mapper;
    private readonly UserDbContext _dbContext;

    public GetAllUsersQueryHandler(UserDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    
    public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users.AsNoTracking().ToListAsync(cancellationToken);
        return _mapper.Map<List<UserDTO>>(users);
    }
}