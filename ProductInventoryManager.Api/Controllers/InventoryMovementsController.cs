using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductInventoryManager.Application.Features.InventoryMovement.Commands.CreateInventoryMovement;
using ProductInventoryManager.Application.Features.InventoryMovement.Queries.GetAllInventoryMovements;
using ProductInventoryManager.Application.Features.InventoryMovement.Queries.GetInventoryMovementDetails;

namespace ProductInventoryManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryMovementsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryMovementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<InventoryMovementDto>> Get()
        {
            var inventoryMovements = await _mediator.Send(new GetInventoryMovementsQuery());
            return inventoryMovements;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryMovementDetailsDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetInventoryMovementDetailsQuery(id));
            return Ok(leaveType);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateInventoryMovementCommand inventoryMovement)
        {
            var response = await _mediator.Send(inventoryMovement);
            return CreatedAtAction(nameof(Get), new { id = response });
        }
    }
}