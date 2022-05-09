using FluentValidation;
using Trabs_BLL.Models;

namespace Trab_API.Validation
{
    public class WorkValidator : AbstractValidator<Work>
    {
        public WorkValidator()
        {
            RuleFor(w => w.Name)
                .MinimumLength(3).WithMessage("The name must be longer than 3 characters")
                .NotNull().WithMessage("Enter name")
                .NotEmpty().WithMessage("Enter Name")
                .MaximumLength(30).WithMessage("the name must be less than 50 caracts");

            RuleFor(w => w.Description)
              .MinimumLength(2).WithMessage("The description must be longer than 1 characters")
              .NotNull().WithMessage("Enter description")
              .NotEmpty().WithMessage("Enter description")
              .MaximumLength(1000).WithMessage("the description must be less than 1000 caracts");

        }
    }
}
