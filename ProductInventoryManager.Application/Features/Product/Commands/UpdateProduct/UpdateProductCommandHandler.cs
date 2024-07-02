using AutoMapper;
using MediatR;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Exceptions;

namespace ProductInventoryManager.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _ProductRepository;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository ProductRepository)
        {
            _mapper = mapper;
            _ProductRepository = ProductRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {            
            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {                
                throw new BadRequestException("Invalid Product", validationResult);
            }            
            var ProductToUpdate = _mapper.Map<Domain.Product>(request);            
            await _ProductRepository.UpdateAsync(ProductToUpdate);
            
            return Unit.Value;
        }
    }
}