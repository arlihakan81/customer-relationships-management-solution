namespace CRM.Application.Dtos.Contact
{
    public class CreateContactDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public Guid CompanyId { get; set; }
    }

    public class UpdateContactDto : CreateContactDto { }
}
