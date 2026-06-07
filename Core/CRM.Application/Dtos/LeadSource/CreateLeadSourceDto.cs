namespace CRM.Application.Dtos.LeadSource
{
    public class CreateLeadSourceDto
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateLeadSourceDto : CreateLeadSourceDto { }

}
