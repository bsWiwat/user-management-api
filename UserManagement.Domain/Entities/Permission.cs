namespace UserManagement.Domain.Entities
{
    public class Permission
    {
        public Guid PermissionId { get; set; }
        public string PermissionName { get; set; } = string.Empty;

        public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
    }
}