using FluentValidation;

namespace Application.Features.Locations.Commands.Create;

public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationCommandValidator()
    {
        RuleFor(c => c.City)
            .NotEmpty().WithMessage("City cannot be empty")
            .WithName("Location Create City");

        RuleFor(c => c.Address)
            .NotEmpty().WithMessage("Address cannot be empty")
            .WithName("Location Create Address");

        RuleFor(c => c.Latitute)
            .NotEmpty().WithMessage("Latitute cannot be empty")
            .Must(BeAValidLatitude).WithMessage("Latitute must be a valid latitude value between -90 and 90")
            .WithName("Location Create Latitute");

        RuleFor(c => c.Longtitute)
            .NotEmpty().WithMessage("Longtitute cannot be empty")
            .Must(BeAValidLongitude).WithMessage("Longtitute must be a valid longitude value between -180 and 180")
            .WithName("Location Create Longtitute");
    }

    private bool BeAValidLatitude(string latitute)
    {
        return double.TryParse(latitute, out double value) && value >= -90 && value <= 90;
    }

    private bool BeAValidLongitude(string longtitute)
    {
        return double.TryParse(longtitute, out double value) && value >= -180 && value <= 180;
    }
}