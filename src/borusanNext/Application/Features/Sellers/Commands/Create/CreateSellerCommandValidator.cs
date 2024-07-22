using FluentValidation;

namespace Application.Features.Sellers.Commands.Create;

public class CreateSellerCommandValidator : AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.LicenceId).NotEmpty();
        RuleFor(c => c.LocationId).NotEmpty();
    }
}