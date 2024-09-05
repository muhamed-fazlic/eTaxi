using eTaxi.Application.DTOs.Rating;
using eTaxi.Application.DTOs.ToDo;
using eTaxi.Application.Features.Rating.Commands;
using eTaxi.Application.Features.Rating.Queries;
using eTaxi.Application.Features.ToDo.Commands;
using eTaxi.Application.Features.ToDo.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTaxi.API.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ToDoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] ToDoSearchDto Search)
        {
            var result = await _mediator.Send(new GetToDoListQuery() { Search = Search });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateToDoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteToDoCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
