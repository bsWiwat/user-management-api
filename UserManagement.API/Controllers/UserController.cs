using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Permissions.Commands.CreatePermission;
using UserManagement.Application.Features.Roles.Commands.CreateRole;
using UserManagement.Application.Features.Users.Commands.CreateUser;

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

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("create-permission")]
        public async Task<IActionResult> CreatePermission([FromBody] CreatePermissionCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}