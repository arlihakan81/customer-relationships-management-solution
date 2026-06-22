using CRM.Application.Dtos.Product;

namespace CRM.Application.Dtos.DealLineItem
{
    public class DealLineItemDto
    {
        public virtual ProductDto Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
