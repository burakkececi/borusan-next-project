using FluentValidation;

namespace Application.Features.Licences.Commands.Delete;

public class DeleteLicenceCommandValidator : AbstractValidator<DeleteLicenceCommand>
{
    public DeleteLicenceCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Licence Delete Id");
    }
}