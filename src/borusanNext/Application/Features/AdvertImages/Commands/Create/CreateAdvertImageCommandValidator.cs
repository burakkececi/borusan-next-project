using FluentValidation;

namespace Application.Features.AdvertImages.Commands.Create;

public class CreateAdvertImageCommandValidator : AbstractValidator<CreateAdvertImageCommand>
{
    public CreateAdvertImageCommandValidator()
    {
        RuleFor(c => c.AdvertId).NotEmpty();
        RuleFor(c => c.ImageURL).NotEmpty();
    }
}