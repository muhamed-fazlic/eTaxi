using eTaxi.Application.DTOs.Rating;
using eTaxi.Application.Features.Rating.Commands;
using eTaxi.Application.Features.Rating.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eTaxi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {

        private readonly IMediator _mediator;

        public RatingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RatingSearchDto Search)
        {
            var result = await _mediator.Send(new GetRatingListQuery() { Search = Search });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRatingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRatingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteRatingCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
