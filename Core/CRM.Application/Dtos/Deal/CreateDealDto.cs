using CRM.Application.Dtos.DealLineItem;

namespace CRM.Application.Dtos.Deal
{
    public class CreateDealDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid StageId { get; set; }
        public DateTime CloseDate { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? ContactId { get; set; }
    }

    public class UpdateDealDto : CreateDealDto { }
}
