using FluentValidation;
using System;

namespace Application.Features.Campaigns.Commands.Delete
{
    public class DeleteCampaignCommandValidator : AbstractValidator<DeleteCampaignCommand>
    {
        public DeleteCampaignCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .Must(BeAValidGuid).WithMessage("Id must be a valid GUID format.");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
