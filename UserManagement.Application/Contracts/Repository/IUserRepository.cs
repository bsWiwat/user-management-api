using UserManagement.Application.Models;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(CreateUserDto user);
        Task<User> GetUserByIdAsync(Guid userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid userId);

        Task<Role> AddRoleAsync(string roleName);
        Task<Role> GetRoleByIdAsync(Guid roleId);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Guid roleId);

        Task<Permission> AddPermissionAsync(string permissionName);
        Task<Permission> GetPermissionByIdAsync(Guid permissionId);
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task UpdatePermissionAsync(Permission permission);
        Task DeletePermissionAsync(Guid permissionId);
    }
}