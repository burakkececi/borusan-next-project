using FluentValidation;

namespace Application.Features.Licences.Commands.Create;

public class CreateLicenceCommandValidator : AbstractValidator<CreateLicenceCommand>
{
    public CreateLicenceCommandValidator()
    {
        RuleFor(c => c.LicenceNo).NotEmpty();
        RuleFor(c => c.ProvidedBy).NotEmpty();
    }
}