using FluentValidation;

namespace Application.Features.Adverts.Commands.Create;

public class CreateAdvertCommandValidator : AbstractValidator<CreateAdvertCommand>
{
    public CreateAdvertCommandValidator()
    {
        RuleFor(c => c.AdvertNo).NotEmpty();
        RuleFor(c => c.FeaturedImageURL).NotEmpty();
        //RuleFor(c => c.CarId).NotEmpty();
    }
}