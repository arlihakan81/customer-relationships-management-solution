using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Product : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<Deal>? Deals { get; set; }

    }
}
