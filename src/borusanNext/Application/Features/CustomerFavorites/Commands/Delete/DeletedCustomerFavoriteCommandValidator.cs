using FluentValidation;

namespace Application.Features.CustomerFavorites.Commands.Delete;

public class DeleteCustomerFavoriteCommandValidator : AbstractValidator<DeleteCustomerFavoriteCommand>
{
    public DeleteCustomerFavoriteCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}