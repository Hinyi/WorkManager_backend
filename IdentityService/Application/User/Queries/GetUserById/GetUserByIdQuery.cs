using IdentityService.Application.User.DTOs;
using IdentityService.Application.User.DTOs;
using MediatR;

namespace IdentityService.Application.User.Queries.GetUserById;

public record GetUserByIdQuery(string Id) : IRequest<UserDTO>;
