using CRM.Domain.Entities;

namespace CRM.Application.Dtos.Deal
{
    public class DealDto
    {
        public Guid DealId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public Guid StageId { get; set; }
        public DateTime CloseDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? ContactId { get; set; }
        public decimal ExpectedRevenue { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
