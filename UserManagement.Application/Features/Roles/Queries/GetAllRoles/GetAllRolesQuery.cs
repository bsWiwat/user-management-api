using MediatR;
using UserManagement.Application.Common.Responses;

namespace UserManagement.Application.Features.Roles.Queries.GetAllRoles;

public class GetAllRolesQuery : IRequest<BaseResponse<List<RoleDTO>>>
{
}