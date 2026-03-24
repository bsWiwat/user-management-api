using MediatR;
using UserManagement.Application.Common.Responses;

namespace UserManagement.Application.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdQuery : IRequest<BaseResponse<RoleDTO>>
{
    public Guid RoleId { get; set; }

}