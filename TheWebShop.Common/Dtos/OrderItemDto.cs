namespace TheWebShop.Common.Dtos
{
    public class OrderItemDto
    {
        public int OrderEntityId { get; set; }
        
        public OrderDto Order { get; set; }

        public int ProductEntityId { get; set; }
        
        public ProductDto Product { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal PricePerProduct { get; set; }
        
        public decimal Total { get; set; }
    }
}