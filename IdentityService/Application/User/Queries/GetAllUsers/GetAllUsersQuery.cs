using IdentityService.Application.User.DTOs;
using MediatR;

namespace IdentityService.Application.User.Queries.GetAllUsers;

public record GetAllUsersQuery : IRequest<List<UserDTO>>;