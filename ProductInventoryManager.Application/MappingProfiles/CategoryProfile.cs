using AutoMapper;
using ProductInventoryManager.Application.Features.Category.Commands.CreateCategory;
using ProductInventoryManager.Application.Features.Category.Commands.UpdateCategory;
using ProductInventoryManager.Application.Features.Category.Queries.GetAllCategories;
using ProductInventoryManager.Application.Features.Category.Queries.GetCategoryDetails;
using ProductInventoryManager.Domain;

namespace ProductInventoryManager.Application.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CategoryDetailsDto, Category>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}