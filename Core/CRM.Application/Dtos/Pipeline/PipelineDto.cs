namespace CRM.Application.Dtos.Pipeline
{
    public class PipelineDto
    {
        public Guid PipelineId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
