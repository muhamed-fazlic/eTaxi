using eTaxi.Application.DTOs.User;
using eTaxi.Application.Features.User.Commands.CreateUser;
using eTaxi.Application.Features.User.Commands.DeleteUser;
using eTaxi.Application.Features.User.Commands.UpdateUser;
using eTaxi.Application.Features.User.Queries.GetById;
using eTaxi.Application.Features.User.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eTaxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public IMediator _mediator { get; }

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetUserListQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<UserDto> Get(int id)
        {
            var user = await _mediator.Send(new GetUserDetailsQuery(id));
            return user;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateUserCommand user)
        {
            var response = await _mediator.Send(user);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateUserCommand user)
        {
            await _mediator.Send(user);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
