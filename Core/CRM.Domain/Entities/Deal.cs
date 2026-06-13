using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Deal : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public decimal? Amount => Products?.Sum(p => p.Price) ?? 0;
        public Guid StageId { get; set; }
        public DateTime CloseDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? ContactId { get; set; }
        public decimal? ExpectedRevenue
        {
            get
            {
                // Güvenli null kontrolü
                if (Amount.HasValue && Stage.Probability.HasValue)
                    return Amount.Value * Stage.Probability.Value;
                return 0;
            }
        }
        public virtual Stage Stage { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Contact? Contact { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<DealItem>? Items { get; set; }

    }
}
