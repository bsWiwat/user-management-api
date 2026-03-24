public class UserResponseDTO
{
    public Guid UserId { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string Username { get; set; } = string.Empty;

    public RoleDTO Role { get; set; } = new();

    public List<PermissionDTO> Permissions { get; set; } = new();

    public DateTime DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public DateTime? DateDelete { get; set; }
}