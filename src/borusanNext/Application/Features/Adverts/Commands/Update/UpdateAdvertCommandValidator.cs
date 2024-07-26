using FluentValidation;

namespace Application.Features.Adverts.Commands.Update;

public class UpdateAdvertCommandValidator : AbstractValidator<UpdateAdvertCommand>
{
    public UpdateAdvertCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AdvertNo).NotEmpty();
        RuleFor(c => c.FeaturedImageURL).NotEmpty();
        RuleFor(c => c.CarId).NotEmpty();
    }
}