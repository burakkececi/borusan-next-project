using FluentValidation;
using System;

namespace Application.Features.Adverts.Commands.Create
{
    public class CreateAdvertCommandValidator : AbstractValidator<CreateAdvertCommand>
    {
        public CreateAdvertCommandValidator()
        {
            RuleFor(c => c.AdvertNo)
                .NotNull().WithMessage("Advert Number cannot be null.")
                .GreaterThan(0).WithMessage("Advert Number must be greater than 0.");

            RuleFor(c => c.CarId)
                .NotNull().WithMessage("Car ID cannot be null.")
                .Must(BeAValidGuid).WithMessage("Car ID must be a valid GUID.");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
