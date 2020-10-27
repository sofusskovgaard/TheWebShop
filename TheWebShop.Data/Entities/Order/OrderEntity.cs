using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TheWebShop.Data.Entities.OrderItem;
using TheWebShop.Data.Entities.User;

namespace TheWebShop.Data.Entities.Order
{
    [Table("Orders")]
    public class OrderEntity : BaseEntity, IOrderEntity
    {
        public int? UserEntityId { get; set; }
        
        public UserEntity Customer { get; set; }
        
        public int TotalQuantity { get; set; }
        
        public decimal Total { get; set; }
        
        public decimal TotalTax { get; set; }
        
        public ICollection<OrderItemEntity> Items { get; set; }
    }
}