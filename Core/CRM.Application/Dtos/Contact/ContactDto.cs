using CRM.Application.Dtos.Company;

namespace CRM.Application.Dtos.Contact
{
    public class ContactDto
    {
        public Guid ContactId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public virtual CompanyDto Company { get; set; } = null!;
    }
}
