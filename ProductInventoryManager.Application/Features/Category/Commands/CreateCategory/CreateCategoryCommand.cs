﻿using MediatR;

namespace ProductInventoryManager.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}