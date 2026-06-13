namespace CRM.Application.Dtos.Stage
{
    public class StageDto
    {
        public Guid StageId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Order { get; set; }
        public decimal Probability { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
