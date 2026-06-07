namespace CRM.Application.Dtos.LeadSource
{
    public class LeadSourceDto
    {
        public Guid LeadSourceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
