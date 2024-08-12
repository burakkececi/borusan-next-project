using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace Application.Features.Campaigns.Commands.Create
{
    public class CreateCampaignCommandValidator : AbstractValidator<CreateCampaignCommand>
    {
        public CreateCampaignCommandValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description cannot be empty.");

            RuleFor(c => c.Banner)
                .NotEmpty().WithMessage("Banner cannot be empty.")
                .Must(BeAValidImage).WithMessage("Banner must be a valid image file.");
        }

        private bool BeAValidImage(IFormFile banner)
        {
            if (banner == null || banner.Length == 0)
                return false;

            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
            string fileExtension = Path.GetExtension(banner.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
                return false;

            return true;
        }
    }
}
