using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class DealItem : BaseEntity<Guid>
    {
        public Guid DealId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        public virtual Deal Deal { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
