using CRM.Application.Dtos.Company;

namespace CRM.Application.Dtos.Company
{
    public class CompanyDetailDto : CompanyDto
    {
        public string? Description { get; set; }
        public string? Phone { get; set; }
        public string? AlternatePhone { get; set; }
        public string? Fax { get; set; }
        public string? Website { get; set; }
        public string? Source { get; set; }
        public string? Industry { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Skype { get; set; }
        public string? LinkedIn { get; set; }
        public string? Whatsapp { get; set; }
        public string? X_Url { get; set; }
    }
}
