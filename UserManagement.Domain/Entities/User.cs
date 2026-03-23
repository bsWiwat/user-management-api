namespace UserManagement.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime DateCreate { get; set; } = DateTime.UtcNow;
        public DateTime? DateUpdate { get; set; } = null;
        public DateTime? DateDelete { get; set; } = null;

        public ICollection<UserPermission> Permissions { get; set; } = new List<UserPermission>();
    }
}