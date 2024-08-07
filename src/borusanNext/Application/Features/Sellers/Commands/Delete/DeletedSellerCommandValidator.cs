using FluentValidation;

namespace Application.Features.Sellers.Commands.Delete;

public class DeleteSellerCommandValidator : AbstractValidator<DeleteSellerCommand>
{
    public DeleteSellerCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Seller Delete Id");
    }
}