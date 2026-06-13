using CRM.Application.Dtos.DealItem;

namespace CRM.Application.Dtos.Deal
{
    public class CreateDealDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid StageId { get; set; }
        public DateTime CloseDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? ContactId { get; set; }

        public virtual ICollection<DealItemDto>? Products { get; set; }
    }

    public class UpdateDealDto : CreateDealDto { }
}
