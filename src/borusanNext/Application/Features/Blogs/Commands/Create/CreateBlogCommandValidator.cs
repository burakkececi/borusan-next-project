using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.RegularExpressions;

namespace Application.Features.Blogs.Commands.Create
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(c => c.Title)
                .NotNull().WithMessage("Title cannot be null.")
                .NotEmpty().WithMessage("Title cannot be empty.")
                .Length(5, 100).WithMessage("Title must be between 5 and 100 characters long.");

            RuleFor(c => c.Description)
                .NotNull().WithMessage("Description cannot be null.")
                .NotEmpty().WithMessage("Description cannot be empty.")
                .Length(10, 1000).WithMessage("Description must be between 10 and 1000 characters long.");

            RuleFor(c => c.Banner)
                .Must(BeAValidFile).WithMessage("Banner must be a valid image file (jpg, jpeg, png, gif) with size less than 5MB.")
                .NotNull().WithMessage("Banner cannot be null.");
        }
        private bool BeAValidFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var maxFileSizeInMB = 5;
            var extension = System.IO.Path.GetExtension(file.FileName).ToLowerInvariant();
            var maxFileSizeInBytes = maxFileSizeInMB * 1024 * 1024;

            if (file.Length > maxFileSizeInBytes)
                return false;

            if (Array.IndexOf(allowedExtensions, extension) < 0)
                return false;

            return true;
        }
    }
}
