using MediatR;
using UserManagement.Application.Common.Responses;

namespace UserManagement.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleCommand : IRequest<BaseResponse<RoleDTO>>
{
    public string RoleName { get; set; } = string.Empty;
}
