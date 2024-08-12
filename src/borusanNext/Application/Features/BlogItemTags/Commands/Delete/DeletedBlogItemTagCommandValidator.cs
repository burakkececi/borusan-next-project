using FluentValidation;
using System;

namespace Application.Features.BlogItemTags.Commands.Delete
{
    public class DeleteBlogItemTagCommandValidator : AbstractValidator<DeleteBlogItemTagCommand>
    {
        public DeleteBlogItemTagCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id cannot be empty.")
                .Must(BeValidGuid).WithMessage("Id must be a valid GUID.");
        }
        private bool BeValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
