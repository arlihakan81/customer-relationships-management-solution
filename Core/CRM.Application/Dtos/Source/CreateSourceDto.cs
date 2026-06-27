namespace CRM.Application.Dtos.Source
{
    public class CreateSourceDto
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateSourceDto : CreateSourceDto { }

}
