using TheWebShop.Data.Entities.Order;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.OrderItem
{
    public class OrderItemEntity : BaseEntity, IOrderItemEntity
    {
        public int OrderEntityId { get; set; }
        
        public OrderEntity Order { get; set; }
        
        public int ProductItemEntity { get; set; }
        
        public ProductEntity Product { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal PricePerProduct { get; set; }
        
        public decimal Total { get; set; }
    }
}