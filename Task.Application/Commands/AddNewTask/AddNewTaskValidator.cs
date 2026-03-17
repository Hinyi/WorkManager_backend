using FluentValidation;

namespace Task.Application.Commands.AddNewTask;

public class AddNewTaskValidator : AbstractValidator<AddNewTaskCommand>
{
    public AddNewTaskValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty()
            .MinimumLength(50)
            .WithMessage("First name must be less than 50 characters");
        ;
    }
}