using AutoMapper;
using MediatR;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Exceptions;

namespace ProductInventoryManager.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {            
            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Category", validationResult);            
            var categoryToCreate = _mapper.Map<Domain.Category>(request);            
            await _categoryRepository.CreateAsync(categoryToCreate);
            
            return categoryToCreate.Id;
        }
    }
}