using CRM.Application.Dtos.LeadLabel;
using CRM.Domain.Entities;

namespace CRM.Application.Dtos.Lead
{
    public class CreateLeadDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public Guid SourceId { get; set; }

        public virtual ICollection<LeadLabelDto>? LeadLabels { get; set; }
    }

    public class UpdateLeadDto : CreateLeadDto { }
}
