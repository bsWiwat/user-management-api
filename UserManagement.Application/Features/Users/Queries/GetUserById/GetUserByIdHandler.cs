using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Contracts.Repository;

namespace UserManagement.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, BaseResponse<UserResponseDTO>>
{
    private readonly IUserRepository _userRepository;
    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<UserResponseDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);

        if (user == null)
        {
            return new BaseResponse<UserResponseDTO>
            {
                Status = new StatusResponse
                {
                    Code = "404",
                    Description = "User not found"
                },
                Data = null
            };
        }

        return new BaseResponse<UserResponseDTO>
        {
            Status = new StatusResponse
            {
                Code = "200",
                Description = "User retrieved successfully"
            },
            Data = new UserResponseDTO
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
            }
        };
    }
}