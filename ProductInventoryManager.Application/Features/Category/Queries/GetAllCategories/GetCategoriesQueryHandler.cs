using AutoMapper;
using MediatR;
using ProductInventoryManager.Application.Contracts.Persistence;

namespace ProductInventoryManager.Application.Features.Category.Queries.GetAllCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAsync();
            var data= _mapper.Map<List<CategoryDto>>(categories);

            return data;
        }
    }
}