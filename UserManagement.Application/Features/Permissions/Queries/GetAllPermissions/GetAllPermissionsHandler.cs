using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Contracts.Repository;

namespace UserManagement.Application.Features.Permissions.Queries.GetAllPermissions;

public class GetAllPermissionsHandler : IRequestHandler<GetAllPermissionsQuery, BaseResponse<List<PermissionDTO>>>
{
    private readonly IUserRepository _userRepository;
    public GetAllPermissionsHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<List<PermissionDTO>>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
    {
        var permissions = await _userRepository.GetAllPermissionsAsync();
        var permissionDTOs = permissions.Select(p => new PermissionDTO
        {
            PermissionId = p.PermissionId,
            PermissionName = p.PermissionName,
        }).ToList();

        return new BaseResponse<List<PermissionDTO>>
        {
            Status = new StatusResponse
            {
                Code = "200",
                Description = "Role retrieved successfully"
            },
            Data = permissionDTOs
        };
    }
}