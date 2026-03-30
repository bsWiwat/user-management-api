using MediatR;
using UserManagement.Application.Common.Responses;

namespace UserManagement.Application.Features.Permissions.Queries.GetAllPermissions;

public class GetAllPermissionsQuery : IRequest<BaseResponse<List<PermissionDTO>>>
{
}