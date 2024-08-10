using FluentValidation;

namespace Application.Features.Licences.Commands.Create;

public class CreateLicenceCommandValidator : AbstractValidator<CreateLicenceCommand>
{
    public CreateLicenceCommandValidator()
    {
        RuleFor(c => c.LicenceNo)
            .NotEmpty().WithMessage("LicenceNo cannot be empty")
            .Must(BeExactlySevenDigits).WithMessage("LicenceNo must be exactly 7 digits long")
            .WithName("Licence Create Licence No");

        RuleFor(c => c.ProvidedBy)
            .NotEmpty().WithMessage("ProvidedBy cannot be empty")
            .WithName("Licence Create Provided By");

    }
    private bool BeExactlySevenDigits(int licenceNo)
    {
        return licenceNo >= 1000000 && licenceNo <= 9999999;
    }
}