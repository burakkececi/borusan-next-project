using FluentValidation;

namespace Application.Features.BodyShellParts.Commands.Delete
{
    public class DeleteBodyShellPartCommandValidator : AbstractValidator<DeleteBodyShellPartCommand>
    {
        public DeleteBodyShellPartCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .Must(BeValidGuid).WithMessage("Id cannot be empty GUID.");
        }

        private bool BeValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
