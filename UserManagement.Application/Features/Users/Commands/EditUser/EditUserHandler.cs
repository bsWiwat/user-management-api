using MediatR;
using UserManagement.Application.Common.Responses;
using UserManagement.Application.Contracts.Repository;
using UserManagement.Application.Models;
using Microsoft.AspNetCore.Identity;

namespace UserManagement.Application.Features.Users.Commands.EditUser;

public class EditUserHandler : IRequestHandler<EditUserCommand, BaseResponse<UserResponseDTO>>
{
    private readonly IUserRepository _userRepository;
    public EditUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<UserResponseDTO>> Handle(EditUserCommand request, CancellationToken cancellationToken)
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

        var now = DateTime.UtcNow;
        var passwordHasher = new PasswordHasher<object>();
        string? hashedPassword = null;

        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            hashedPassword = passwordHasher.HashPassword(null, request.Password);
        }

        var userUpdate = new CreateUserDto
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            RoleId = request.RoleId,
            Username = request.Username,
            Password = hashedPassword,

            Permissions = request.Permissions.Select(p => new CreateUserPermissionDto
            {
                PermissionId = p.PermissionId,
                IsReadable = p.IsReadable,
                IsWritable = p.IsWritable,
                IsDeletable = p.IsDeletable
            }).ToList(),

            DateUpdate = now
        };


        await _userRepository.UpdateUserAsync(request.UserId, userUpdate);

        return new BaseResponse<UserResponseDTO>
        {
            Status = new StatusResponse
            {
                Code = "200",
                Description = "User updated successfully"
            },
            Data = new UserResponseDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Username = user.Username,
                Role = user.Role != null ? new RoleDTO
                {
                    RoleId = user.Role.RoleId,
                    RoleName = user.Role.RoleName
                } : null,
                Permissions = user.Permissions.Select(p => new PermissionDTO
                {
                    PermissionId = p.PermissionId,
                    PermissionName = p.Permission.PermissionName,
                }).ToList(),
                DateCreate = user.DateCreate,
                DateUpdate = user.DateUpdate,
                DateDelete = user.DateDelete
            }
        };
    }
}