using FluentValidation;

namespace ProductInventoryManager.Application.Features.InventoryMovement.Commands.CreateInventoryMovement
{
    public class CreateInventoryMovementCommandValidator : AbstractValidator<CreateInventoryMovementCommand>
    {
        public CreateInventoryMovementCommandValidator()
        {
            RuleFor(p => p.ProductId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(p => p.MovementTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(p => p.Quantity)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");
        }
    }
}