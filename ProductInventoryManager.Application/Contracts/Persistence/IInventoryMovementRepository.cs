﻿using ProductInventoryManager.Domain;

namespace ProductInventoryManager.Application.Contracts.Persistence
{
    public interface IInventoryMovementRepository : IGenericRepository<InventoryMovement>
    {
    }
}