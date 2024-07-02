using AutoMapper;
using MediatR;
using ProductInventoryManager.Application.Contracts.Persistence;

namespace ProductInventoryManager.Application.Features.Product.Queries.GetAllProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAsync();
            var data= _mapper.Map<List<ProductDto>>(products);

            return data;
        }
    }
}