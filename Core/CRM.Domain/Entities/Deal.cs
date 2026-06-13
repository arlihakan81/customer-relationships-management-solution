using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Deal : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Amount => Products?.Sum(p => p.Price) ?? 0;
        public Guid StageId { get; set; }
        public DateTime CloseDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? ContactId { get; set; }
        public decimal ExpectedRevenue => Amount * (Stage.Probability / 100);

        public virtual Stage Stage { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
        public virtual Contact? Contact { get; set; }
        public virtual ICollection<Product>? Products { get; set; }


    }
}
