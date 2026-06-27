using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Deal : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public decimal? Value
        {
            get
            {
                return Value;
            }
            set
            {
                if (Items is null)
                {
                    _ = value;
                }
                else
                {
                    _ = Items.Sum(item => item.TotalPrice);
                }
            }
        }
        public Guid StageId { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? ContactId { get; set; }
        public decimal? ExpectedRevenue
        {
            get
            {
                // Güvenli null kontrolü
                if (Value.HasValue && Stage.Probability.HasValue)
                    return Value.Value * (Stage.Probability.Value / 100);
                return 0;
            }
        }
        public virtual Stage Stage { get; set; } = null!;
        public Enums.Status Status { get; set; } = Enums.Status.Open;
        public virtual Company Company { get; set; } = null!;
        public virtual Contact? Contact { get; set; }
        public virtual ICollection<DealLineItem>? Items { get; set; }

    }
}
