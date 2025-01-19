using FluentValidation;

namespace Users.Aplication.User.Command.CreateUserCommand;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email is not valid");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6).
            WithMessage("Password must be at least 6 characters long");
        
    }
    
}