namespace UserManagement.Domain.Entities
{
    public class UserPermission
    {
        public Guid UserPermissionId { get; set; }
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }

        public bool IsReadable { get; set; } = false;
        public bool IsWritable { get; set; } = false;
        public bool IsDeletable { get; set; } = false;

        public User User { get; set; } = null!;
        public Permission Permission { get; set; } = null!;
    }
}