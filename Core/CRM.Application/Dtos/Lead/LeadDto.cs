using CRM.Application.Dtos.Label;
using CRM.Application.Dtos.Source;

namespace CRM.Application.Dtos.Lead
{
    public class LeadDto
    {
        public Guid LeadId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public bool IsConverted { get; set; } = false;
        public SourceDto Source { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<LabelDto>? Labels { get; set; }
    }
}
