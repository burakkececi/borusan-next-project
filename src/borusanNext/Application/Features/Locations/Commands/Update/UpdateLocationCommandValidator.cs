using FluentValidation;

namespace Application.Features.Locations.Commands.Update;

public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Latitute).NotEmpty();
        RuleFor(c => c.Longitute).NotEmpty();
    }
}