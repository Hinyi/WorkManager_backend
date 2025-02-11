using MediatR;

namespace IdentityService.Aplication.User.Command.LoginUser;

public record LoginUserCommand(string Email, string password) : IRequest<string>;
