using FluentValidation.Results;
using MediatR;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Exceptions;

namespace ProductInventoryManager.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _categoryRepository.GetByIdAsync(request.Id);
            if (categoryToDelete == null)
                throw new NotFoundException(nameof(categoryToDelete), request.Id);
            var products = await _productRepository.GetProductsByCategory(request.Id);
            if (products != null && products.Count > 0)
            {
                ValidationResult validationResult = new ValidationResult();

                validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.Id),
                    "Category cannot be deleted because it has associated products."));
                throw new BadRequestException("Invalid Delete Category", validationResult);
            }
            await _categoryRepository.DeleteAsync(categoryToDelete);

            return Unit.Value;
        }
    }
}