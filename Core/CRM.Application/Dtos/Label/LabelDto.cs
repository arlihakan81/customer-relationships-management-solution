namespace CRM.Application.Dtos.Label
{
    public class LabelDto
    {
        public Guid LabelId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
