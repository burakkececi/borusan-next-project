using FluentValidation;
using System;

namespace Application.Features.CustomerFavorites.Commands.Update
{
    public class UpdateCustomerFavoriteCommandValidator : AbstractValidator<UpdateCustomerFavoriteCommand>
    {
        public UpdateCustomerFavoriteCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .NotNull().WithMessage("Id cannot be null.")
                .Must(BeAValidGuid).WithMessage("Id must be a valid GUID.");

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
