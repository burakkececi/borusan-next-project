using FluentValidation;

namespace Application.Features.ExpertizeResults.Commands.Update;

public class UpdateExpertizeResultCommandValidator : AbstractValidator<UpdateExpertizeResultCommand>
{
    public UpdateExpertizeResultCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CarDamageInformationRecord).NotEmpty();
        RuleFor(c => c.InquiryDate).NotEmpty();
        RuleFor(c => c.ChassisPartId).NotEmpty();
        RuleFor(c => c.BodyShellPartId).NotEmpty();
    }
}