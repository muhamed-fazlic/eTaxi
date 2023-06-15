using eTaxi.Application.Features.Favorite.Commands;
using eTaxi.Application.Features.Favorite.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTaxi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FavoriteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoriteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int UserId)
        {
            var result = await _mediator.Send(new GetFavoriteListQuery() { UserId = UserId });
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var query = new GetFavoriteQuery(id);
        //    var result = await _mediator.Send(query);
        //    return Ok(result);
        //}

        [HttpPost]
        public async Task<IActionResult> Create(CreateFavoriteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteFavoriteCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFavoriteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
