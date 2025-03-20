using IdentityService.Application.User.DTOs;
using IdentityService.Application.User.DTOs;
using MediatR;

namespace IdentityService.Application.User.Command.UpdateUser;

public record UpdateUserCommand(string userId, string username) : IRequest<UserDTO>;