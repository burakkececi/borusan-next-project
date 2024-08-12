using FluentValidation;
using System;

namespace Application.Features.AdvertImages.Commands.Delete
{
    public class DeleteAdvertImageCommandValidator : AbstractValidator<DeleteAdvertImageCommand>
    {
        public DeleteAdvertImageCommandValidator()
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
