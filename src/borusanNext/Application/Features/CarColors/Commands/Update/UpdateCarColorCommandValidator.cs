using FluentValidation;
using System;

namespace Application.Features.CarColors.Commands.Update
{
    public class UpdateCarColorCommandValidator : AbstractValidator<UpdateCarColorCommand>
    {
        public UpdateCarColorCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .Must(BeValidGuid).WithMessage("Id must be a valid GUID format.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");
        }

        private bool BeValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
