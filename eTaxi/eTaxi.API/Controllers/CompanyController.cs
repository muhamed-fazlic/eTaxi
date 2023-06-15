using eTaxi.Application.Features.Company.Commands;
using eTaxi.Application.Features.Company.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTaxi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetCompanyListQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetCompanyQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        //[HttpPut]
        //public async Task<IActionResult> Update(UpdateCompanyCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCompanyCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
