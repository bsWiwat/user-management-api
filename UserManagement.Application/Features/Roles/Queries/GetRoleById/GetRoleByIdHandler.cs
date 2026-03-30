using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Contracts.Repository;

namespace UserManagement.Application.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, BaseResponse<RoleDTO>>
{
    private readonly IUserRepository _userRepository;
    public GetRoleByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<RoleDTO>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _userRepository.GetRoleByIdAsync(request.RoleId);
        var roleDTO = role == null ? null : new RoleDTO
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName,
        };
        if (role == null)
        {
            return new BaseResponse<RoleDTO>
            {
                Status = new StatusResponse
                {
                    Code = "404",
                    Description = "Role not found"
                },
                Data = null
            };
        }

        return new BaseResponse<RoleDTO>
        {
            Status = new StatusResponse
            {
                Code = "200",
                Description = "Role retrieved successfully"
            },
            Data = roleDTO
        };
    }
}