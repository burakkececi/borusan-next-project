using FluentValidation;

namespace Application.Features.ModalExtensions.Commands.Create;

public class CreateModalExtensionCommandValidator : AbstractValidator<CreateModalExtensionCommand>
{
    public CreateModalExtensionCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .WithName("Name");

        RuleFor(c => c.Lenght)
            .NotEmpty().WithMessage("Lenght cannot be empty")
            .GreaterThan(0).WithMessage("Lenght must be greater than 0")
            .WithName("Lenght");

        RuleFor(c => c.Width)
            .NotEmpty().WithMessage("Width cannot be empty")
            .GreaterThan(0).WithMessage("Width must be greater than 0")
            .WithName("Width");

        RuleFor(c => c.Height)
            .NotEmpty().WithMessage("Height cannot be empty")
            .GreaterThan(0).WithMessage("Height must be greater than 0")
            .WithName("Height");

        RuleFor(c => c.FuelTank)
            .NotEmpty().WithMessage("FuelTank cannot be empty")
            .GreaterThan(0).WithMessage("FuelTank must be greater than 0")
            .WithName("FuelTank");

        RuleFor(c => c.LuggageCapacity)
            .NotEmpty().WithMessage("LuggageCapacity cannot be empty")
            .GreaterThan(0).WithMessage("LuggageCapacity must be greater than 0")
            .WithName("LuggageCapacity");

        RuleFor(c => c.EmptyWeight)
            .NotEmpty().WithMessage("EmptyWeight cannot be empty")
            .GreaterThan(0).WithMessage("EmptyWeight must be greater than 0")
            .WithName("EmptyWeight");

        RuleFor(c => c.ModelYear)
            .NotEmpty().WithMessage("ModelYear cannot be empty")
            .GreaterThan(1900).WithMessage("ModelYear must be greater than 1900")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("ModelYear must be less than or equal to the current year")
            .WithName("ModelYear");

        RuleFor(c => c.CarModelId)
            .NotEmpty().WithMessage("CarModelId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("CarModelId cannot be an empty GUID")
            .WithName("CarModelId");

        RuleFor(c => c.GenerationId)
            .NotEmpty().WithMessage("GenerationId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("GenerationId cannot be an empty GUID")
            .WithName("GenerationId");
    }
}