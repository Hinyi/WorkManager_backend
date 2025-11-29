using MediatR;

namespace IdentityService.Application.User.Command.CreateUser;

public record CreateUserResponse(Guid Id);

public record CreateUserCommand(string Email, string FirstName, string LastName, string Password, string ConfirmPassword) : IRequest<CreateUserResponse>;
