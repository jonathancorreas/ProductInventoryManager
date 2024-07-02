using MediatR;

namespace ProductInventoryManager.Application.Features.Category.Queries.GetAllCategories
{
    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}