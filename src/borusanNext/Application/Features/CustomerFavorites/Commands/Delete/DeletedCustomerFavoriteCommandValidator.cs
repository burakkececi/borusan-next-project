using FluentValidation;
using System;

namespace Application.Features.CustomerFavorites.Commands.Delete
{
    public class DeleteCustomerFavoriteCommandValidator : AbstractValidator<DeleteCustomerFavoriteCommand>
    {
        public DeleteCustomerFavoriteCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .NotNull().WithMessage("Id cannot be null.")
                .Must(BeAValidGuid).WithMessage("Id must be a valid GUID.");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
