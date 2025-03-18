using MediatR;

namespace IdentityService.Aplication.User.Command.CreateUser;

public record CreateUserCommand(string Email, string FirstName, string LastName, string Password, string ConfirmPassword) : IRequest<string>
{
    
}