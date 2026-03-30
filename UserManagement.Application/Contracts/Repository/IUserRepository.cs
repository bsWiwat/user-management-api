using UserManagement.Application.Models;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(CreateUserDto user);
        Task<User> GetUserByIdAsync(Guid userId);
        Task<(List<User> Data, int Total)> GetAllUsersAsync(SearchModel searchModel);
        Task<User> UpdateUserAsync(Guid id, CreateUserDto user);
        Task<bool> DeleteUserAsync(Guid userId);

        Task<Role> AddRoleAsync(string roleName);
        Task<Role> GetRoleByIdAsync(Guid roleId);
        Task<List<Role>> GetAllRolesAsync();
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Guid roleId);

        Task<Permission> AddPermissionAsync(string permissionName);
        Task<Permission> GetPermissionByIdAsync(Guid permissionId);
        Task<List<Permission>> GetAllPermissionsAsync();
        Task UpdatePermissionAsync(Permission permission);
        Task DeletePermissionAsync(Guid permissionId);
    }
}