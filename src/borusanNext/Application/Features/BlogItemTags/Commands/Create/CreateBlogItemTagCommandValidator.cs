using FluentValidation;

namespace Application.Features.BlogItemTags.Commands.Create;

public class CreateBlogItemTagCommandValidator : AbstractValidator<CreateBlogItemTagCommand>
{
    public CreateBlogItemTagCommandValidator()
    {
        RuleFor(c => c.TagId).NotEmpty();
        RuleFor(c => c.BlogId).NotEmpty();
    }
}