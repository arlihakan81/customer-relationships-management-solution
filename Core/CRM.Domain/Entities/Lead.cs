using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Lead : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public Guid SourceId { get; set; }
        public bool IsConverted { get; set; } = false;
        public string Address { get; set; } = string.Empty;

        public virtual LeadSource Source { get; set; } = null!;
        public virtual ICollection<LeadLabel>? LeadLabels { get; set; }
        public virtual ICollection<Label>? Labels { get; set; }



    }
}
