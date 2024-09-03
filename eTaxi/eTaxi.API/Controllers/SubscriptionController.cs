using eTaxi.Application.DTOs.Rating;
using eTaxi.Application.DTOs.Subscription;
using eTaxi.Application.Features.Rating.Commands;
using eTaxi.Application.Features.Rating.Queries;
using eTaxi.Application.Features.Subscription.Commands;
using eTaxi.Application.Features.Subscription.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTaxi.API.Controllers
{
 

    [ApiController]
    [Route("api/[controller]")]
   // [Authorize]
    public class SubscriptionController : ControllerBase
    {

        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] SubscriptionSearchDto Search)
        {
            var result = await _mediator.Send(new GetSubscriptionListQuery() { Search=Search});
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscriptionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSubscriptionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteSubscriptionCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
