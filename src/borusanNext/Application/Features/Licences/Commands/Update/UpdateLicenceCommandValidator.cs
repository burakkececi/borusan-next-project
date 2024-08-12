using FluentValidation;

namespace Application.Features.Licences.Commands.Update;

public class UpdateLicenceCommandValidator : AbstractValidator<UpdateLicenceCommand>
{
    public UpdateLicenceCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Licence Update Id");

        RuleFor(c => c.LicenceNo)
            .NotEmpty().WithMessage("LicenceNo cannot be empty")
            .Must(BeExactlySevenDigits).WithMessage("LicenceNo must be exactly 7 digits long")
            .WithName("Licence Create Licence No");

        RuleFor(c => c.ProvidedBy)
            .NotEmpty().WithMessage("ProvidedBy cannot be empty")
            .WithName("Licence Create Provided By");
        ;
    }

    private bool BeExactlySevenDigits(int licenceNo)
    {
        return licenceNo >= 1000000 && licenceNo <= 9999999;
    }
}