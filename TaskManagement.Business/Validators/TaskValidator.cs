using FluentValidation;
using TaskManagement.Entities.Entities;

namespace TaskManagement.Business.Validators
{
    public class TaskValidator : AbstractValidator<TaskDetail>
    {
        public TaskValidator()
        {
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required")
                .LessThan(x => DateTime.Now).WithMessage("Start date cannot be in the past");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required")
                .GreaterThan(x => x.StartDate).WithMessage("End date must be greater than start date");
        }
    }
}
