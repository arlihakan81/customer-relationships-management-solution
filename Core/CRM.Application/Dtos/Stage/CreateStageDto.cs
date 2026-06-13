namespace CRM.Application.Dtos.Stage
{
    public class CreateStageDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Order { get; set; }
        public decimal Probability { get; set; }
        public Guid PipelineId { get; set; }
    }

    public class UpdateStageDto : CreateStageDto { }
}
