using FluentValidation;

namespace Application.Features.Transmissions.Commands.Delete;

public class DeleteTransmissionCommandValidator : AbstractValidator<DeleteTransmissionCommand>
{
    public DeleteTransmissionCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Transmission Delete Id");
    }
}