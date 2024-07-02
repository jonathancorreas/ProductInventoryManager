using AutoMapper;
using ProductInventoryManager.Application.Features.Product.Commands.CreateProduct;
using ProductInventoryManager.Application.Features.Product.Commands.UpdateProduct;
using ProductInventoryManager.Application.Features.Product.Queries.GetAllProducts;
using ProductInventoryManager.Application.Features.Product.Queries.GetProductDetails;
using ProductInventoryManager.Domain;

namespace ProductInventoryManager.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductDetailsDto, Product>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}