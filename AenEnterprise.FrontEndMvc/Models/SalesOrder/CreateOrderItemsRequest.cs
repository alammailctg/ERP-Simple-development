namespace AenEnterprise.FrontEndMvc.Models.SalesOrder
{
    public class CreateOrderItemsRequest
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal? DiscountPercent { get; set; } 
        public string Description { get; set; } = string.Empty;
    }
}
