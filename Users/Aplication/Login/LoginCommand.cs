using MediatR;

namespace Users.Aplication.Login;

public record LoginCommand(string Email) : IRequest<string>;
