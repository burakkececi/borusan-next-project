using FluentValidation;
using System;

namespace Application.Features.Adverts.Commands.Update
{
    public class UpdateAdvertCommandValidator : AbstractValidator<UpdateAdvertCommand>
    {
        public UpdateAdvertCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull().WithMessage("ID cannot be null.")
                .NotEmpty().WithMessage("ID cannot be empty.")
                .Must(BeAValidGuid).WithMessage("ID must be a valid GUID.");

            RuleFor(c => c.AdvertNo)
                .NotNull().WithMessage("Advert Number cannot be null.")
                .GreaterThan(0).WithMessage("Advert Number must be greater than 0.");

            RuleFor(c => c.CarId)
                .NotNull().WithMessage("Car ID cannot be null.")
                .NotEmpty().WithMessage("Car ID cannot be empty.")
                .Must(BeAValidGuid).WithMessage("Car ID must be a valid GUID.");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
