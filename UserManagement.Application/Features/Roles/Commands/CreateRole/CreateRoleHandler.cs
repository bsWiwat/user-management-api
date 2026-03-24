
using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Contracts.Repository;

namespace UserManagement.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, BaseResponse<RoleDTO>>
{
    private readonly IUserRepository _userRepository;

    public CreateRoleHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<RoleDTO>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _userRepository.AddRoleAsync(request.RoleName);

        if (role == null)
        {
            return new BaseResponse<RoleDTO>
            {
                Status = new StatusResponse
                {
                    Code = "400",
                    Description = "Role is already exists or failed to create"
                },
                Data = null
            };
        }

        return new BaseResponse<RoleDTO>
        {
            Status = new StatusResponse
            {
                Code = "200",
                Description = "Role created successfully"
            },
            Data = role == null ? null : new RoleDTO
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            }
        };
    }
}