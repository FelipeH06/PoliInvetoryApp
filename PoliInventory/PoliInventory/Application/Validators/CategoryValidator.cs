using FluentValidation;
using PoliInventory.Application.DTOs;

namespace PoliInventory.Application.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .MinimumLength(5);

            RuleFor(c => c.Description)
                .MaximumLength(2000);

            RuleFor(c=>c.State)
                .NotNull();
        }
    }
}
