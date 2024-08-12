using FluentValidation;

namespace Application.Features.BodyTypes.Commands.Delete;

public class DeleteBodyTypeCommandValidator : AbstractValidator<DeleteBodyTypeCommand>
{
    public DeleteBodyTypeCommandValidator()
    {
        RuleFor(c => c.Id)
                 .NotEmpty().WithMessage("Id cannot be empty.")
                 .NotNull().WithMessage("Id cannot be null.")
                 .Must(BeAValidGuid).WithMessage("Id must be a valid GUID format.");
    }
    private bool BeAValidGuid(Guid guid)
    {
        return guid != Guid.Empty;
    }
}