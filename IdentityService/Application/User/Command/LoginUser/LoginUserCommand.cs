using MediatR;

namespace IdentityService.Application.User.Command.LoginUser;

public record LoginUserCommand(string Email, string password) : IRequest<LoginUserResponse>;
