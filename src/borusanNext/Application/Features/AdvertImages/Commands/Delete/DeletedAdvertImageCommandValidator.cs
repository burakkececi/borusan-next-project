using FluentValidation;

namespace Application.Features.AdvertImages.Commands.Delete;

public class DeleteAdvertImageCommandValidator : AbstractValidator<DeleteAdvertImageCommand>
{
    public DeleteAdvertImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}