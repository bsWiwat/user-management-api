using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Contracts.Repository;

namespace UserManagement.Application.Features.Permissions.Queries.GetPermissionById;

public class GetPermissionByIdHandler : IRequestHandler<GetPermissionByIdQuery, BaseResponse<PermissionDTO>>
{
    private readonly IUserRepository _userRepository;
    public GetPermissionByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<PermissionDTO>> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
    {
        var permission = await _userRepository.GetPermissionByIdAsync(request.PermissionId);
        var permissionDTO = permission == null ? null : new PermissionDTO
        {
            PermissionId = permission.PermissionId,
            PermissionName = permission.PermissionName,
        };

        if (permission == null)
        {
            return new BaseResponse<PermissionDTO>
            {
                Status = new StatusResponse
                {
                    Code = "404",
                    Description = "Permission not found"
                },
                Data = null
            };
        }

        return new BaseResponse<PermissionDTO>
        {
            Status = new StatusResponse
            {
                Code = "200",
                Description = "Permission retrieved successfully"
            },
            Data = permissionDTO
        };
    }
}