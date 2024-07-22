using FluentValidation;

namespace Application.Features.Licences.Commands.Update;

public class UpdateLicenceCommandValidator : AbstractValidator<UpdateLicenceCommand>
{
    public UpdateLicenceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LicenceNo).NotEmpty();
        RuleFor(c => c.LicenceOwner).NotEmpty();
    }
}