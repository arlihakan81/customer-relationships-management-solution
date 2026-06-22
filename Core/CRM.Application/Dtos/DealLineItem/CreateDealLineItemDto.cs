namespace CRM.Application.Dtos.DealLineItem
{
    public class CreateDealLineItemDto
    {
        public Guid DealId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
