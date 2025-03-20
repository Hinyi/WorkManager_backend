using IdentityService.Application.User.DTOs;
using IdentityService.Application.User.DTOs;
using MediatR;

namespace IdentityService.Application.User.Queries.GetUserByEmail;

public record GetUserByEmailQuery(string email) : IRequest<UserDTO>;
