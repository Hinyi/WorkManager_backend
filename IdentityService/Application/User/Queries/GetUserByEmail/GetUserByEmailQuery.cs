using IdentityService.Aplication.User.DTOs;
using MediatR;

namespace IdentityService.Aplication.User.Queries.GetUserByEmail;

public record GetUserByEmailQuery(string email) : IRequest<UserDTO>;
