using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Pipeline : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Stage>? Stages { get; set; }

    }
}
