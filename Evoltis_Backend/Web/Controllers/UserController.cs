using Application.Common.Models;
using Application.User.Commands.CreateUser;
using Application.User.Commands.UpdateUser;
using Application.User.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<ResponseObjectJsonDto>> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseObjectJsonDto>> GetUser([FromQuery] GetUserQuery query)
        {
            var result = await Mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseObjectJsonDto>> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseObjectJsonDto>> GetAllUsers([FromQuery] GetAllUsersQuery query)
        {
            var result = await Mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

    }
}
