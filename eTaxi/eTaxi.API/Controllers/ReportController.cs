using eTaxi.Application.Contracts.Reports;
using eTaxi.Application.DTOs.Reports;
using eTaxi.Application.Features.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eTaxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController:Controller
    {
        private readonly IMediator _mediator;
        public ReportController( IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<ReportDto>> GetReport([FromQuery] ReportSearchDTO search)
        {
            var result = await _mediator.Send(new GetReportQuery() { Search=search});
            return Ok(result);
        }   
    }
}
