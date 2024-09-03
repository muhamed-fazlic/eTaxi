using eTaxi.Application.DTOs.Membership;
using eTaxi.Application.DTOs.Rating;
using eTaxi.Application.Features.Membership.Commands;
using eTaxi.Application.Features.Membership.Queries;
using eTaxi.Application.Features.Rating.Commands;
using eTaxi.Application.Features.Rating.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTaxi.API.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
   // [Authorize]
    public class MembershipController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MembershipController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] MembershipSearchDto Search)
        {
            var result = await _mediator.Send(new GetMembershipListQuery() { Search = Search });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMembershipCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMembershipCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMembershipCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
