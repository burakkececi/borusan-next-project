using FluentValidation;

namespace Application.Features.CustomerFavorites.Commands.Update;

public class UpdateCustomerFavoriteCommandValidator : AbstractValidator<UpdateCustomerFavoriteCommand>
{
    public UpdateCustomerFavoriteCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.AdvertId).NotEmpty();
    }
}