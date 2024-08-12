using FluentValidation;

namespace Application.Features.Transmissions.Commands.Update;

public class UpdateTransmissionCommandValidator : AbstractValidator<UpdateTransmissionCommand>
{
    public UpdateTransmissionCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Transmission Update Id");

        RuleFor(c => c.Name)
             .NotEmpty().WithMessage("Name cannot be empty")
             .WithName("Name"); ;
    }
}