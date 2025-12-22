using FluentValidation;

namespace IdentityService.Application.User.Command.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.newPassword)
            .NotEmpty()
            .MinimumLength(6).WithMessage("New password must be at least 6 characters long")
            .WithMessage("New password is not valid");
        
        RuleFor(x => x.newPassword).Equal(x => x.confirmNewPassword)
            .WithMessage("Passwords do not match");
        
        
    }
}