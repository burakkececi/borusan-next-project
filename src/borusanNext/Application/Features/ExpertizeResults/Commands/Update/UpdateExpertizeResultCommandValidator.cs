using FluentValidation;

namespace Application.Features.ExpertizeResults.Commands.Update;

public class UpdateExpertizeResultCommandValidator : AbstractValidator<UpdateExpertizeResultCommand>
{
    public UpdateExpertizeResultCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("ExpertizeResults Update Id");

        RuleFor(c => c.CarDamageInformationRecord)
            .GreaterThan(0).WithMessage("CarDamageInformationRecord must be greater than 0")
            .WithName("ExpertizeResults Update Car Damage Information Record");

        RuleFor(c => c.InquiryDate)
            .NotEmpty().WithMessage("InquiryDate cannot be empty")
            .WithName("ExpertizeResults Update Inquiry Date");

        RuleFor(c => c.ChassisPartId)
            .NotEmpty().WithMessage("ChassisPartId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("ChassisPartId cannot be an empty GUID")
            .WithName("ExpertizeResults Update Chassis Part ID");

        RuleFor(c => c.BodyShellPartId)
            .NotEmpty().WithMessage("BodyShellPartId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("BodyShellPartId cannot be an empty GUID")
            .WithName("ExpertizeResults Update Body Shell Part ID");
    }
}