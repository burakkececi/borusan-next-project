using FluentValidation;

namespace Application.Features.ExpertizeResults.Commands.Create;

public class CreateExpertizeResultCommandValidator : AbstractValidator<CreateExpertizeResultCommand>
{
    public CreateExpertizeResultCommandValidator()
    {
        RuleFor(c => c.CarDamageInformationRecord).NotEmpty();
        RuleFor(c => c.InquiryDate).NotEmpty();
    }
}