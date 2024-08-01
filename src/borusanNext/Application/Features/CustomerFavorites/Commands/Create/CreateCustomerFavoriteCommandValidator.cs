using FluentValidation;

namespace Application.Features.CustomerFavorites.Commands.Create;

public class CreateCustomerFavoriteCommandValidator : AbstractValidator<CreateCustomerFavoriteCommand>
{
    public CreateCustomerFavoriteCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.AdvertId).NotEmpty();
    }
}