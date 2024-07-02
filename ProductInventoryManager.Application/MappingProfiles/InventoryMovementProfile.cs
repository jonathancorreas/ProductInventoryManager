using AutoMapper;
using ProductInventoryManager.Application.Features.InventoryMovement.Commands.CreateInventoryMovement;
using ProductInventoryManager.Application.Features.InventoryMovement.Queries.GetAllInventoryMovements;
using ProductInventoryManager.Application.Features.InventoryMovement.Queries.GetInventoryMovementDetails;
using ProductInventoryManager.Domain;

namespace ProductInventoryManager.Application.MappingProfiles
{
    public class InventoryMovementProfile : Profile
    {
        public InventoryMovementProfile()
        {
            CreateMap<InventoryMovementDto, InventoryMovement>().ReverseMap();
            CreateMap<InventoryMovementDetailsDto, InventoryMovement>().ReverseMap();
            CreateMap<CreateInventoryMovementCommand, InventoryMovement>();
        }
    }
}