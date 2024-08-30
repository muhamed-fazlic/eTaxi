using eTaxi.Application.DTOs.FITPasos;
using eTaxi.Application.DTOs.Order;
using eTaxi.Application.Features.FITPasos.Commands;
using eTaxi.Application.Features.FITPasos.Queries;
using eTaxi.Application.Features.Order.Commands;
using eTaxi.Application.Features.Order.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTaxi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class FITPasosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FITPasosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] FITPasosSearchDto request)
        {
            var result = await _mediator.Send(new GetFITPasosListQuery() { Search = request });
            return Ok(result);
        }

     

        [HttpPost]
        public async Task<IActionResult> Create(CreateFITPasosCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFITPasosCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

     

        [HttpDelete("{id}")]
       // [Authorize(Roles = "Admin,CompanyAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteFitPasosCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
