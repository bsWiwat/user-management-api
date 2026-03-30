using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Permissions.Commands.CreatePermission;
using UserManagement.Application.Features.Permissions.Queries.GetAllPermissions;
using UserManagement.Application.Features.Permissions.Queries.GetPermissionById;
using UserManagement.Application.Features.Roles.Commands.CreateRole;
using UserManagement.Application.Features.Roles.Queries.GetAllRoles;
using UserManagement.Application.Features.Roles.Queries.GetRoleById;
using UserManagement.Application.Features.Users.Commands.CreateUser;
using UserManagement.Application.Features.Users.Commands.DeleteUser;
using UserManagement.Application.Features.Users.Commands.EditUser;
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

        [HttpPut("user/{id}")]
        public async Task<IActionResult> EditUser(Guid id, [FromBody] EditUserCommand command)
        {
            command.UserId = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand { UserId = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUserQuery query)
        {
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

        [HttpGet("roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var query = new GetAllRolesQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("role/{id}")]
        public async Task<IActionResult> GetRoleById(Guid id)
        {
            var query = new GetRoleByIdQuery { RoleId = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("permission")]
        public async Task<IActionResult> CreatePermission([FromBody] CreatePermissionCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("permissions")]
        public async Task<IActionResult> GetAllPermissions()
        {
            var query = new GetAllPermissionsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("permission/{id}")]
        public async Task<IActionResult> GetPermissionById(Guid id)
        {
            var query = new GetPermissionByIdQuery { PermissionId = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

    }
}