using IdentityService.Aplication.User.DTOs;
using MediatR;

namespace IdentityService.Aplication.User.Queries.GetUserById;

public record GetUserByIdQuery(string Id) : IRequest<UserDTO>;
