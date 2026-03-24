using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Contracts.Repository;

namespace UserManagement.Application.Features.Users.Queries.GetAllUser;

public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, BaseResponse<List<UserResponseDTO>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<List<UserResponseDTO>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllUsersAsync();

        return new BaseResponse<List<UserResponseDTO>>
        {
            Status = new StatusResponse
            {
                Code = "200",
                Description = "Users retrieved successfully"
            },
            Data = users.Select(user => new UserResponseDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Username = user.Username,
                Role = new RoleDTO
                {
                    RoleId = user.Role.RoleId,
                    RoleName = user.Role.RoleName
                },
                Permissions = user.Permissions.Select(p => new PermissionDTO
                {
                    PermissionId = p.PermissionId,
                    PermissionName = p.Permission.PermissionName,
                }).ToList()
            }).ToList()
        };
    }
}