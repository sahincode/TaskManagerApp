using TaskManagerApp.Domain.Entities;
using FluentValidation;

namespace TaskManagerApp.UI.Infrastructure.Validators;

public class TaskItemValidator : AbstractValidator<TaskItem>
{
    public TaskItemValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");
        
        RuleFor(x => x.Deadline)
            .Must(BeAValidDeadline)
            .When(x => x.Deadline.HasValue)
            .WithMessage("Deadline cannot be in the past.");
    }

    private bool BeAValidDeadline(DateTime? deadline)
    {
        if (!deadline.HasValue)
            return true;
        return deadline.Value.Date >= DateTime.UtcNow.Date;
    }
}