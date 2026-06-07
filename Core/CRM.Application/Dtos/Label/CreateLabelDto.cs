namespace CRM.Application.Dtos.Label
{
    public class CreateLabelDto
    {
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class UpdateLabelDto : CreateLabelDto
    {

    }



}
