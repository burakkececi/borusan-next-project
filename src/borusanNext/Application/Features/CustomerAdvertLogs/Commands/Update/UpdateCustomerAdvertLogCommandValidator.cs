using FluentValidation;
using System;

namespace Application.Features.CustomerAdvertLogs.Commands.Update
{
    public class UpdateCustomerAdvertLogCommandValidator : AbstractValidator<UpdateCustomerAdvertLogCommand>
    {
        public UpdateCustomerAdvertLogCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.");

            RuleFor(c => c.CustomerId)
                .NotEmpty().WithMessage("CustomerId cannot be empty.")
                .Must(BeAValidGuid).WithMessage("CustomerId must be a valid GUID.");

            RuleFor(c => c.AdvertId)
                .NotEmpty().WithMessage("AdvertId cannot be empty.")
                .Must(BeAValidGuid).WithMessage("AdvertId must be a valid GUID.");

            RuleFor(c => c.ContactStatus)
                .NotEmpty().WithMessage("ContactStatus cannot be empty.")
                .NotNull().WithMessage("ContactStatus cannot be null.")
                .IsInEnum().WithMessage("ContactStatus must be a valid enum value.");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
