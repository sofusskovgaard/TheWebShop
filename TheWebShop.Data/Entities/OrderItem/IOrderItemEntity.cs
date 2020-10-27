using TheWebShop.Data.Entities.Order;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.OrderItem
{
    public interface IOrderItemEntity : IBaseEntity
    {
        int OrderEntityId { get; set; }
        
        OrderEntity Order { get; set; }
        
        int ProductItemEntity { get; set; }
        
        ProductEntity Product { get; set; }
        
        int Quantity { get; set; }
        
        decimal PricePerProduct { get; set; }
        
        decimal Total { get; set; }
    }
}