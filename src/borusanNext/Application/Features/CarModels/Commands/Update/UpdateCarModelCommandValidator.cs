using FluentValidation;
using System;

namespace Application.Features.CarModels.Commands.Update
{
    public class UpdateCarModelCommandValidator : AbstractValidator<UpdateCarModelCommand>
    {
        public UpdateCarModelCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .Must(BeValidGuid).WithMessage("Id must be a valid GUID format.");

            RuleFor(c => c.ModelName)
                .NotEmpty().WithMessage("Model Name cannot be empty.")
                .MaximumLength(100).WithMessage("Model Name cannot exceed 100 characters.");

            RuleFor(c => c.BrandId)
                .NotEmpty().WithMessage("Brand Id cannot be empty.")
                .Must(BeValidGuid).WithMessage("Brand Id must be a valid GUID format.");
        }

        private bool BeValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
