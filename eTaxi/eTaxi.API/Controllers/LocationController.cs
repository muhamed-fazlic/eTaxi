using eTaxi.Application.Features.Location.Commands;
using eTaxi.Application.Features.Location.Queries;
using eTaxi.Application.Features.VehicleType.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eTaxi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetLocationQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLocationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLocationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteLocationCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
