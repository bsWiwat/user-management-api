using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Contracts.Repository;
using UserManagement.Application.Models;

namespace UserManagement.Application.Features.Users.Commands.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, BaseResponse<UserResponseDTO>>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<UserResponseDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;

        var user = await _userRepository.AddUserAsync(new CreateUserDto
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            RoleId = request.RoleId,
            Username = request.Username,
            Password = request.Password,

            DateCreate = now,
            DateUpdate = now,
            DateDelete = null,

            Permissions = request.Permissions.Select(p => new CreateUserPermissionDto
            {
                PermissionId = p.PermissionId,
                IsReadable = p.IsReadable,
                IsWritable = p.IsWritable,
                IsDeletable = p.IsDeletable
            }).ToList()
        });

        return new BaseResponse<UserResponseDTO>
        {
            Status = new StatusResponse
            {
                Code = "200",
                Description = "User created successfully"
            },
            Data = user == null ? null : new UserResponseDTO
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
                    RoleName = user.Role?.RoleName ?? string.Empty
                },
                DateCreate = user.DateCreate,
                DateUpdate = user.DateUpdate,
                DateDelete = user.DateDelete,

                Permissions = user.Permissions.Select(up => new PermissionDTO
                {
                    PermissionId = up.PermissionId,
                    PermissionName = up.Permission?.PermissionName ?? string.Empty
                }).ToList()
            }

        };
    }
}