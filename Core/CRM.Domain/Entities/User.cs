namespace CRM.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Avatar { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public bool IsEmailConfirmed { get; set; } = false;
        public int RoleId { get; set; }
        public Guid OrganizationId { get; set; }
        
        public virtual Role Role { get; set; }
        public virtual Organization Organization { get; set; }

    }
}
