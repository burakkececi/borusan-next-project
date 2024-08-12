using FluentValidation;
using System;

namespace Application.Features.CustomerFavorites.Commands.Create
{
    public class CreateCustomerFavoriteCommandValidator : AbstractValidator<CreateCustomerFavoriteCommand>
    {
        public CreateCustomerFavoriteCommandValidator()
        {
            RuleFor(c => c.CustomerId)
                .NotEmpty().WithMessage("CustomerId cannot be empty.")
                .NotNull().WithMessage("CustomerId cannot be null.")
                .Must(BeAValidGuid).WithMessage("CustomerId must be a valid GUID.");

            RuleFor(c => c.AdvertId)
                .NotEmpty().WithMessage("AdvertId cannot be empty.")
                .NotNull().WithMessage("AdvertId cannot be null.")
                .Must(BeAValidGuid).WithMessage("AdvertId must be a valid GUID.");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
