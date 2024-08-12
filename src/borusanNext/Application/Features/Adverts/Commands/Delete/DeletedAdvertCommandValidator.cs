using FluentValidation;
using System;

namespace Application.Features.Adverts.Commands.Delete
{
    public class DeleteAdvertCommandValidator : AbstractValidator<DeleteAdvertCommand>
    {
        public DeleteAdvertCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull().WithMessage("ID cannot be null.")
                .NotEmpty().WithMessage("ID cannot be empty.")
                .Must(BeAValidGuid).WithMessage("ID must be a valid GUID.");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
