using MediatR;
using UserManagement.Application.Common.Responses;

namespace UserManagement.Application.Features.Permissions.Queries.GetPermissionById;

public class GetPermissionByIdQuery : IRequest<BaseResponse<PermissionDTO>>
{
    public Guid PermissionId { get; set; }
}