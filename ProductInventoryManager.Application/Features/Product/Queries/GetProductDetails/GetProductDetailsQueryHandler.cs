using AutoMapper;
using MediatR;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Exceptions;

namespace ProductInventoryManager.Application.Features.Product.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsDto>
    {

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductDetailsQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductDetailsDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {            
            var product = await _productRepository.GetByIdAsync(request.Id);            
            if (product == null)
                throw new NotFoundException(nameof(product), request.Id);
            
            var data = _mapper.Map<ProductDetailsDto>(product);
            
            return data;
        }
    }
}