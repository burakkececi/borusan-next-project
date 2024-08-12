using FluentValidation;
using System;

namespace Application.Features.CarColors.Commands.Delete
{
    public class DeleteCarColorCommandValidator : AbstractValidator<DeleteCarColorCommand>
    {
        public DeleteCarColorCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .Must(BeValidGuid).WithMessage("Id must be a valid GUID format.");
        }

        private bool BeValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
