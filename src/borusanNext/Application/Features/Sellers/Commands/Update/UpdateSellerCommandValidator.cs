using FluentValidation;

namespace Application.Features.Sellers.Commands.Update;

public class UpdateSellerCommandValidator : AbstractValidator<UpdateSellerCommand>
{
    public UpdateSellerCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Seller Delete Id");

        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("UserId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("UserId cannot be an empty GUID")
            .WithName("User ID");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .WithName("Name");

        RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("Phone cannot be empty")
            .Matches(@"^(0\d{3} \d{3} \d{2} \d{2})$").WithMessage("Phone number is not valid")
            .WithName("Phone Number");

        RuleFor(c => c.LicenceId)
            .NotEmpty().WithMessage("LicenceId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("LicenceId cannot be an empty GUID")
            .WithName("Licence ID");

        RuleFor(c => c.LocationId)
            .NotEmpty().WithMessage("LocationId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("LocationId cannot be an empty GUID")
            .WithName("Location ID");
    }
}