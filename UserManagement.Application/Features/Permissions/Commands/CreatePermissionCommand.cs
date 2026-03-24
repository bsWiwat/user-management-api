using MediatR;
using UserManagement.Application.Common.Responses;

namespace UserManagement.Application.Features.Permissions.Commands.CreatePermission;

public class CreatePermissionCommand : IRequest<BaseResponse<PermissionDTO>>
{
    public string PermissionName { get; set; } = string.Empty;
}
