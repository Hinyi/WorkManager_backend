using FluentValidation;

namespace Users.Aplication.User.Command.CreateUserCommand;

internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
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

        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);
        
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(2)
            .WithMessage("First name must be less than 50 characters");

        RuleFor(x => x.LastName).NotEmpty();

    }
    
}