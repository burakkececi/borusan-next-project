using FluentValidation;

namespace Application.Features.Locations.Commands.Delete;

public class DeleteLocationCommandValidator : AbstractValidator<DeleteLocationCommand>
{
    public DeleteLocationCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Location Delete Id");
    }
}