using FluentValidation;

namespace Application.Features.Licences.Commands.Delete;

public class DeleteLicenceCommandValidator : AbstractValidator<DeleteLicenceCommand>
{
    public DeleteLicenceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}