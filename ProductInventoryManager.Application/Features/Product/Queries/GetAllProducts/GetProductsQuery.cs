using MediatR;

namespace ProductInventoryManager.Application.Features.Product.Queries.GetAllProducts
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
    }
}