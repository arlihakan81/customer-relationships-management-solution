namespace CRM.Application.Dtos.Pipeline
{
    public class CreatePipelineDto
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UpdatePipelineDto : CreatePipelineDto { }
}
