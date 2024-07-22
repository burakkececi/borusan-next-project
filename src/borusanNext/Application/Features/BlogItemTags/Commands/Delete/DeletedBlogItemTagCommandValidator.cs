using FluentValidation;

namespace Application.Features.BlogItemTags.Commands.Delete;

public class DeleteBlogItemTagCommandValidator : AbstractValidator<DeleteBlogItemTagCommand>
{
    public DeleteBlogItemTagCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}