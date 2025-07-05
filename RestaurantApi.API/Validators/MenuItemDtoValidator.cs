using FluentValidation;
using RestaurantApi.API.Models;

namespace RestaurantApi.API.Validators
{
    /// <summary>
    /// FluentValidation rules for validating MenuItemDto input models.
    /// </summary>
    public class MenuItemDtoValidator : AbstractValidator<MenuItemDto>
    {
        public MenuItemDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500);

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required.");

            RuleFor(x => x.IsAvailable)
                .NotNull();
        }
    }
}
