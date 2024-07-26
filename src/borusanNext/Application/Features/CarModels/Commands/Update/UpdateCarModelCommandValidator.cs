using FluentValidation;

namespace Application.Features.CarModels.Commands.Update;

public class UpdateCarModelCommandValidator : AbstractValidator<UpdateCarModelCommand>
{
    public UpdateCarModelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ModelName).NotEmpty();
        RuleFor(c => c.BrandId).NotEmpty();
    }
}