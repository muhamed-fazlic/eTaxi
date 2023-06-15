using eTaxi.Application.Features.HubStation.Commands;
using eTaxi.Application.Features.HubStation.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTaxi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HubStationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HubStationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetHubStationListQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHubStationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateHubStationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(DeleteHubStationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
