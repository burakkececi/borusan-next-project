using FluentValidation;

namespace Application.Features.BlogItemTags.Commands.Update;

public class UpdateBlogItemTagCommandValidator : AbstractValidator<UpdateBlogItemTagCommand>
{
    public UpdateBlogItemTagCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TagId).NotEmpty();
        RuleFor(c => c.BlogId).NotEmpty();
    }
}