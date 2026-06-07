using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class LeadLabel : BaseEntity<Guid>
    {
        public Guid LeadId { get; set; }
        public Guid LabelId { get; set; }

        public virtual Lead Lead { get; set; } = null!;
        public virtual Label Label { get; set; } = null!;

    }
}
