using FluentValidation;
using System;

namespace Application.Features.Blogs.Commands.Delete
{
    public class DeleteBlogCommandValidator : AbstractValidator<DeleteBlogCommand>
    {
        public DeleteBlogCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id cannot be empty.")
                .Must(BeAValidGuid).WithMessage("Id must be a valid GUID.");
        }
        private bool BeAValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
