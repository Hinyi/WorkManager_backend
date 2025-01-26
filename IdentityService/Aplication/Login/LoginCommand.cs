using MediatR;

namespace IdentityService.Aplication.Login;

public record LoginCommand(string Email) : IRequest<string>;
