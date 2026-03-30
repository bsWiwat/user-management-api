using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Models;

namespace UserManagement.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<BaseResponse<UserResponseDTO>>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public Guid RoleId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public ICollection<CreateUserPermissionDto> Permissions { get; set; } = new List<CreateUserPermissionDto>();
}
