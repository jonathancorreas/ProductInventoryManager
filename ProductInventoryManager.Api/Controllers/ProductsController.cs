using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductInventoryManager.Application.Features.Product.Commands.CreateProduct;
using ProductInventoryManager.Application.Features.Product.Commands.DeleteProduct;
using ProductInventoryManager.Application.Features.Product.Commands.UpdateProduct;
using ProductInventoryManager.Application.Features.Product.Queries.GetAllProducts;
using ProductInventoryManager.Application.Features.Product.Queries.GetProductDetails;

namespace ProductInventoryManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ProductDto>> Get()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetProductDetailsQuery(id));
            return Ok(leaveType);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateProductCommand product)
        {
            var response = await _mediator.Send(product);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateProductCommand product)
        {
            await _mediator.Send(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}