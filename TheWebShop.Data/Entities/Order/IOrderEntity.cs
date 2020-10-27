using System.Collections.Generic;
using TheWebShop.Data.Entities.OrderItem;
using TheWebShop.Data.Entities.User;

namespace TheWebShop.Data.Entities.Order
{
    public interface IOrderEntity : IBaseEntity
    {
        int? UserEntityId { get; set; }
        
        UserEntity Customer { get; set; }
        
        int TotalQuantity { get; set; }
        
        decimal Total { get; set; }
        
        decimal TotalTax { get; set; }
        
        ICollection<OrderItemEntity> Items { get; set; }
    }
}