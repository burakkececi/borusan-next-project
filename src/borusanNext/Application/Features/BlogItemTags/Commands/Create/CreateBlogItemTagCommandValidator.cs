using FluentValidation;
using System;

namespace Application.Features.BlogItemTags.Commands.Create
{
    public class CreateBlogItemTagCommandValidator : AbstractValidator<CreateBlogItemTagCommand>
    {
        public CreateBlogItemTagCommandValidator()
        {
            RuleFor(c => c.TagId)
                .NotNull().WithMessage("TagId cannot be null.")
                .NotEmpty().WithMessage("TagId cannot be empty.")
                .Must(BeValidGuid).WithMessage("TagId must be a valid GUID.");

            RuleFor(c => c.BlogId)
                .NotNull().WithMessage("BlogId cannot be null.")
                .NotEmpty().WithMessage("BlogId cannot be empty.")
                .Must(BeValidGuid).WithMessage("BlogId must be a valid GUID.");

            RuleFor(c => new { c.TagId, c.BlogId })
                .Must(ids => ids.TagId != ids.BlogId)
                .WithMessage("TagId and BlogId cannot be the same.");
        }

        private bool BeValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
