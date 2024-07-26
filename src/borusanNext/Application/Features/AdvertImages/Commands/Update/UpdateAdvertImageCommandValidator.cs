using FluentValidation;

namespace Application.Features.AdvertImages.Commands.Update;

public class UpdateAdvertImageCommandValidator : AbstractValidator<UpdateAdvertImageCommand>
{
    public UpdateAdvertImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AdvertId).NotEmpty();
        RuleFor(c => c.ImageURL).NotEmpty();
    }
}