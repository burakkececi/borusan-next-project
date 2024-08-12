using FluentValidation;
using System;

namespace Application.Features.BlogItemTags.Commands.Update
{
    public class UpdateBlogItemTagCommandValidator : AbstractValidator<UpdateBlogItemTagCommand>
    {
        public UpdateBlogItemTagCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id cannot be empty.")
                .Must(BeValidGuid).WithMessage("Id must be a valid GUID.");

            RuleFor(c => c.TagId)
                .NotNull().WithMessage("TagId cannot be null.")
                .NotEmpty().WithMessage("TagId cannot be empty.")
                .Must(BeValidGuid).WithMessage("TagId must be a valid GUID.");

            RuleFor(c => c.BlogId)
                .NotNull().WithMessage("BlogId cannot be null.")
                .NotEmpty().WithMessage("BlogId cannot be empty.")
                .Must(BeValidGuid).WithMessage("BlogId must be a valid GUID.");
        }

        private bool BeValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
