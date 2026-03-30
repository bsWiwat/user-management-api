using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Contracts.Repository;

namespace UserManagement.Application.Features.Roles.Queries.GetAllRoles;

public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, BaseResponse<List<RoleDTO>>>
{
    private readonly IUserRepository _userRepository;
    public GetAllRolesHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<List<RoleDTO>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _userRepository.GetAllRolesAsync();
        var roleDTOs = roles.Select(role => new RoleDTO
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName,
        }).ToList();

        return new BaseResponse<List<RoleDTO>>
        {
            Status = new StatusResponse
            {
                Code = "200",
                Description = "Roles retrieved successfully"
            },
            Data = roleDTOs
        };

    }
}