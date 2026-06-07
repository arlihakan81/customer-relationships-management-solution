using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Label : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

        public virtual ICollection<LeadLabel>? LeadLabels { get; set; }
        public virtual ICollection<Lead>? Leads { get; set; }
    }
}
