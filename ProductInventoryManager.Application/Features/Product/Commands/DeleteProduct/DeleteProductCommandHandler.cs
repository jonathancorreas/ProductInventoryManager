using MediatR;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Exceptions;

namespace ProductInventoryManager.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {            
            var productToDelete = await _productRepository.GetByIdAsync(request.Id);            
            if (productToDelete == null)
                throw new NotFoundException(nameof(productToDelete), request.Id);            
            await _productRepository.DeleteAsync(productToDelete);
            
            return Unit.Value;
        }
    }
}