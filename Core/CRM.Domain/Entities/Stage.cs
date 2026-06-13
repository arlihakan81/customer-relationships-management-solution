using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Stage : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Order { get; set; }
        public decimal Probability { get; set; }
        public Guid PipelineId { get; set; }

        public virtual Pipeline Pipeline { get; set; } = null!;
    }
}
