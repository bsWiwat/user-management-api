
using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Contracts.Repository;

namespace UserManagement.Application.Features.Permissions.Commands.CreatePermission;

public class CreatePermissionHandler : IRequestHandler<CreatePermissionCommand, BaseResponse<PermissionDTO>>
{
    private readonly IUserRepository _userRepository;

    public CreatePermissionHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<PermissionDTO>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = await _userRepository.AddPermissionAsync(request.PermissionName);

        if (permission == null)
        {
            return new BaseResponse<PermissionDTO>
            {
                Status = new StatusResponse
                {
                    Code = "400",
                    Description = "Permission is already exists or failed to create"
                },
                Data = null
            };
        }

        return new BaseResponse<PermissionDTO>
        {
            Status = new StatusResponse
            {
                Code = "200",
                Description = "Permission created successfully"
            },
            Data = permission == null ? null : new PermissionDTO
            {
                PermissionId = permission.PermissionId,
                PermissionName = permission.PermissionName
            }
        };
    }
}