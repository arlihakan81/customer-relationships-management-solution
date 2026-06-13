namespace CRM.Application.Dtos.DealItem
{
    public class DealItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
