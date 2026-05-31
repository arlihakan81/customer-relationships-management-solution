using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Contact : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
