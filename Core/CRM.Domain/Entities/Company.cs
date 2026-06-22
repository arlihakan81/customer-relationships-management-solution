using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Company : BaseEntity<Guid>
    {
        public string? Avatar { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Phone { get; set; }
        public string? AlternatePhone { get; set; }
        public string? Fax { get; set; }
        public string? Website { get; set; }
        public string? Source { get; set; }
        public string? Industry { get; set; }
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
        public bool Status { get; set; }
        public Guid OwnerId { get; set; }

        public virtual ICollection<Contact>? Contacts { get; set; }
        public virtual User Owner { get; set; } = null!;


    }
}
