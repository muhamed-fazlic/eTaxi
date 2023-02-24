using eTaxi.Application.DTOs.User;
using eTaxi.Application.Features.User.Commands.CreateUser;
using eTaxi.Application.Features.User.Commands.DeleteUser;
using eTaxi.Application.Features.User.Commands.UpdateUser;
using eTaxi.Application.Features.User.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eTaxi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IMediator _mediator { get; }

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            var user = await _mediator.Send(new GetUserDetailsQuery(id));
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post(CreateUserCommand user)
        {
            var response = await _mediator.Send(user);
            return Ok(user);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<ActionResult> Put(UpdateUserCommand user)
        {
            await _mediator.Send(user);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
