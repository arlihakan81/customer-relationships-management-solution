using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class LeadSource : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;

    }
}
