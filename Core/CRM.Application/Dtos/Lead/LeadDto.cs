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
        public DateTime CreatedDate { get; set; }
    }
}
