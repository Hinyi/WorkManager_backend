using MediatR;

namespace Users.Aplication.User.Command.CreateUserCommand;

public record CreateUserCommand(string Email, string FirstName, string LastName, string Password) : IRequest
{
    
}