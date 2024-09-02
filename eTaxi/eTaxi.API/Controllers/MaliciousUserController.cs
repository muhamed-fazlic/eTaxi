using eTaxi.Application.DTOs.MaliciousUser;
using eTaxi.Application.DTOs.Rating;
using eTaxi.Application.Features.MaliciousUser.Commands;
using eTaxi.Application.Features.MaliciousUser.Queries;
using eTaxi.Application.Features.Rating.Commands;
using eTaxi.Application.Features.Rating.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTaxi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class MaliciousUserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MaliciousUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] MaliciousUserSearchDto Search)
        {
            var result = await _mediator.Send(new GetMaliciousUserListQuery() { Search = Search });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMaliciousUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMaliciousUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var command = new DeleteRatingCommand(id);
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}
    }
}
