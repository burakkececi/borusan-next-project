using FluentValidation;

namespace Application.Features.ExpertizeResults.Commands.Create;

public class CreateExpertizeResultCommandValidator : AbstractValidator<CreateExpertizeResultCommand>
{
    public CreateExpertizeResultCommandValidator()
    {
        RuleFor(c => c.CarDamageInformationRecord)
            .GreaterThan(0).WithMessage("CarDamageInformationRecord must be greater than 0")
            .WithName("ExpertizeResults Create Car Damage Information Record");

        RuleFor(c => c.InquiryDate)
            .NotEmpty().WithMessage("InquiryDate cannot be empty")
            .WithName("ExpertizeResults Create Inquiry Date");

        RuleFor(c => c.ChassisPartId)
            .NotEmpty().WithMessage("ChassisPartId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("ChassisPartId cannot be an empty GUID")
            .WithName("ExpertizeResults Create Chassis Part ID");

        RuleFor(c => c.BodyShellPartId)
            .NotEmpty().WithMessage("BodyShellPartId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("BodyShellPartId cannot be an empty GUID")
            .WithName("ExpertizeResults Create Body Shell Part ID");

    }
}