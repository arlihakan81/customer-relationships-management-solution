using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Contact : BaseEntity<Guid>
    {
        public string? Avatar { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? AlternatePhone { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Skype { get; set; }
        public string? LinkedIn { get; set; }
        public string? Whatsapp { get; set; }
        public string? X_Url { get; set; }
        public string? Description { get; set; }
        public Guid CompanyId { get; set; }
        public Guid OwnerId { get; set; }
        public virtual Company Company { get; set; } = null!;
        public virtual User Owner { get; set; } = null!;



    }
}
