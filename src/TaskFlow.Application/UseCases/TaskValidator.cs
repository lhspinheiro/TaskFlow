using FluentValidation;
using TaskFlow.Communication.Requests;

namespace TaskFlow.Application.UseCases;

public class TaskValidator : AbstractValidator<RequestTask>
{
    public TaskValidator()
    {
        RuleFor(Task => Task.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(Task => Task.Description.Length).GreaterThan(10).WithMessage("Description length must be at least 10.");
        RuleFor(Task => Task.DueDate).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("due date cannot be for the future.");
    }
}