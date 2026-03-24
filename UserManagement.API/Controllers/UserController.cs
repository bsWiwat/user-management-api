using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Permissions.Commands.CreatePermission;
using UserManagement.Application.Features.Roles.Commands.CreateRole;
using UserManagement.Application.Features.Users.Commands.CreateUser;
using UserManagement.Application.Features.Users.Queries.GetAllUser;
using UserManagement.Application.Features.Users.Queries.GetUserById;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUserQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUserByIdQuery { UserId = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("permission")]
        public async Task<IActionResult> CreatePermission([FromBody] CreatePermissionCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}