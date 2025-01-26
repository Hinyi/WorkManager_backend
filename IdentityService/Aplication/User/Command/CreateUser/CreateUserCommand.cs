using MediatR;

namespace IdentityService.Aplication.User.Command.CreateUserCommand;

public record CreateUserCommand(string Email, string FirstName, string LastName, string Password, string ConfirmPassword) : IRequest<string>
{
    
}