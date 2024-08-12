using FluentValidation;
using System;

namespace Application.Features.CarModels.Commands.Create
{
    public class CreateCarModelCommandValidator : AbstractValidator<CreateCarModelCommand>
    {
        public CreateCarModelCommandValidator()
        {
            RuleFor(c => c.ModelName)
                .NotEmpty().WithMessage("Model Name cannot be empty.")
                .MaximumLength(100).WithMessage("Model Name cannot exceed 100 characters.");

            RuleFor(c => c.BrandId)
                .NotEmpty().WithMessage("Brand Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Brand Id must be a valid GUID.");
        }
    }
}
