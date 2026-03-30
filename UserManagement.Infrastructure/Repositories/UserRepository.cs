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

        public Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId && u.DateDelete == null);
            if (user != null)
            {
                user.DateDelete = DateTime.UtcNow;
                _context.Users.Update(user);
                _context.SaveChanges();
            }

            return Task.FromResult(true);
        }

        public async Task<(List<User> Data, int Total)> GetAllUsersAsync(SearchModel searchModel)
        {
            var query = _context.Users
                        .Include(u => u.Role)
                        .Include(u => u.Permissions)
                            .ThenInclude(up => up.Permission)
                        .Where(u => u.DateDelete == null)
                        .AsQueryable();

            if (!string.IsNullOrEmpty(searchModel.search))
            {
                var keyword = searchModel.search.ToLower();

                query = query.Where(u =>
                    u.FirstName.ToLower().Contains(keyword) ||
                    u.LastName.ToLower().Contains(keyword) ||
                    u.Email.ToLower().Contains(keyword)
                );
            }

            var total = await query.CountAsync();

            query = searchModel.orderBy?.ToLower() switch
            {
                "name" => searchModel.orderDirection == "desc"
                    ? query.OrderByDescending(u => u.FirstName)
                    : query.OrderBy(u => u.FirstName),

                "createddate" => searchModel.orderDirection == "desc"
                    ? query.OrderByDescending(u => u.DateCreate)
                    : query.OrderBy(u => u.DateCreate),

                _ => query.OrderByDescending(u => u.DateCreate)
            };

            var data = await query
                .Skip((searchModel.pageNumber - 1) * searchModel.pageSize)
                .Take(searchModel.pageSize)
                .ToListAsync();

            return (data, total);
        }

        public Task<User> GetUserByIdAsync(Guid userId)
        {
            return _context.Users
                           .Include(u => u.Role)
                           .Include(u => u.Permissions)
                               .ThenInclude(up => up.Permission)
                           .FirstOrDefaultAsync(u => u.UserId == userId && u.DateDelete == null);
        }

        public Task<User> UpdateUserAsync(Guid id, CreateUserDto user)
        {
            var existingUser = _context.Users
                                       .Include(u => u.Permissions)
                                       .FirstOrDefault(u => u.UserId == id && u.DateDelete == null);

            if (existingUser == null)
            {
                return Task.FromResult<User>(null);
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;
            existingUser.RoleId = user.RoleId;
            existingUser.Username = user.Username;

            if (!string.IsNullOrEmpty(user.Password))
            {
                existingUser.Password = user.Password;
            }

            existingUser.DateUpdate = user.DateUpdate;

            _context.UserPermissions.RemoveRange(existingUser.Permissions);
            existingUser.Permissions = user.Permissions.Select(p => new UserPermission
            {
                PermissionId = p.PermissionId,
                IsReadable = p.IsReadable,
                IsWritable = p.IsWritable,
                IsDeletable = p.IsDeletable
            }).ToList();

            _context.Users.Update(existingUser);
            _context.SaveChanges();

            return Task.FromResult(existingUser);
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
            return _context.Roles.ToListAsync();
        }

        public Task<Role> GetRoleByIdAsync(Guid roleId)
        {
            return _context.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId);
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
            return _context.Permissions.FirstOrDefaultAsync(p => p.PermissionId == permissionId);
        }

        public Task<List<Permission>> GetAllPermissionsAsync()
        {
            return _context.Permissions.ToListAsync();
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