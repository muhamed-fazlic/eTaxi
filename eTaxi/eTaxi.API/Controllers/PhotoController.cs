using eTaxi.Application.Features.File.Commands;
using eTaxi.Application.Features.File.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTaxi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var files = await _mediator.Send(new GetFileQuery(id));
            return Ok(files);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateFileCommand request)
        {
            var id = await _mediator.Send(request);
            return Ok(id);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteFileCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

    }

}
