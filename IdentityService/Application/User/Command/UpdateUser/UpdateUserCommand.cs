using IdentityService.Aplication.User.DTOs;
using MediatR;

namespace IdentityService.Aplication.User.Command.UpdateUser;

public record UpdateUserCommand(string userId, string username) : IRequest<UserDTO>;