namespace CRM.Application.Dtos.Source
{
    public class SourceDto
    {
        public Guid SourceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
