using FluentValidation;
using System;

namespace Application.Features.CarModels.Commands.Delete
{
    public class DeleteCarModelCommandValidator : AbstractValidator<DeleteCarModelCommand>
    {
        public DeleteCarModelCommandValidator()
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
