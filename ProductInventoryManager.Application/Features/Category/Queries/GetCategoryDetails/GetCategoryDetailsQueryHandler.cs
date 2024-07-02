using AutoMapper;
using MediatR;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Exceptions;

namespace ProductInventoryManager.Application.Features.Category.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto>
    {

        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryDetailsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDetailsDto> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {            
            var category = await _categoryRepository.GetByIdAsync(request.Id);            
            if (category == null)
                throw new NotFoundException(nameof(category), request.Id);            
            var data = _mapper.Map<CategoryDetailsDto>(category);
            
            return data;
        }
    }
}