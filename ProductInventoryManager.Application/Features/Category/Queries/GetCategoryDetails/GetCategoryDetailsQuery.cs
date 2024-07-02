using MediatR;

namespace ProductInventoryManager.Application.Features.Category.Queries.GetCategoryDetails
{
    public record GetCategoryDetailsQuery(int Id) : IRequest<CategoryDetailsDto>;
}