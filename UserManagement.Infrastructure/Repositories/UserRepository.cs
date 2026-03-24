using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Contracts.Repository;
using UserManagement.Application.Models;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(CreateUserDto user)
        {
            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                RoleId = user.RoleId,
                Username = user.Username,
                Password = user.Password,
                DateCreate = user.DateCreate,
                DateUpdate = user.DateUpdate,
                DateDelete = user.DateDelete,

                Permissions = user.Permissions.Select(p => new UserPermission
                {
                    PermissionId = p.PermissionId,
                    IsReadable = p.IsReadable,
                    IsWritable = p.IsWritable,
                    IsDeletable = p.IsDeletable
                }).ToList()
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return await _context.Users
                                .Include(u => u.Role)
                                .Include(u => u.Permissions)
                                    .ThenInclude(up => up.Permission)
                                .FirstAsync(u => u.UserId == newUser.UserId);
        }

        public Task DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            return _context.Users
                           .Include(u => u.Role)
                           .Include(u => u.Permissions)
                               .ThenInclude(up => up.Permission)
                           .Where(u => u.DateDelete == null)
                           .ToListAsync();
        }

        public Task<Role> GetRoleByIdAsync(Guid roleId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(Guid userId)
        {
            return _context.Users
                           .Include(u => u.Role)
                           .Include(u => u.Permissions)
                               .ThenInclude(up => up.Permission)
                           .FirstOrDefaultAsync(u => u.UserId == userId && u.DateDelete == null);
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> AddRoleAsync(string roleName)
        {
            bool isDuplicate = await _context.Roles.AnyAsync(r => r.RoleName == roleName);

            if (isDuplicate)
            {
                return null;
            }

            var newRole = new Role
            {
                RoleId = Guid.NewGuid(),
                RoleName = roleName
            };

            _context.Roles.Add(newRole);
            await _context.SaveChangesAsync();

            return newRole;
        }

        public Task<List<Role>> GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoleAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoleAsync(Guid roleId)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> AddPermissionAsync(string permissionName)
        {
            bool isDuplicate = _context.Permissions.Any(p => p.PermissionName == permissionName);
            if (isDuplicate)
            {
                return Task.FromResult<Permission>(null);
            }

            var newPermission = new Permission
            {
                PermissionId = Guid.NewGuid(),
                PermissionName = permissionName
            };

            _context.Permissions.Add(newPermission);
            _context.SaveChanges();

            return Task.FromResult(newPermission);
        }

        public Task<Permission> GetPermissionByIdAsync(Guid permissionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Permission>> GetAllPermissionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePermissionAsync(Permission permission)
        {
            throw new NotImplementedException();
        }

        public Task DeletePermissionAsync(Guid permissionId)
        {
            throw new NotImplementedException();
        }
    }
}