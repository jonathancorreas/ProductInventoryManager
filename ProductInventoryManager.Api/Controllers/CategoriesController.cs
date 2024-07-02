using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductInventoryManager.Application.Features.Category.Commands.CreateCategory;
using ProductInventoryManager.Application.Features.Category.Commands.DeleteCategory;
using ProductInventoryManager.Application.Features.Category.Commands.UpdateCategory;
using ProductInventoryManager.Application.Features.Category.Queries.GetAllCategories;
using ProductInventoryManager.Application.Features.Category.Queries.GetCategoryDetails;

namespace ProductInventoryManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            return categories;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailsDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetCategoryDetailsQuery(id));
            return Ok(leaveType);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateCategoryCommand category)
        {
            var response = await _mediator.Send(category);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCategoryCommand category)
        {
            await _mediator.Send(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}