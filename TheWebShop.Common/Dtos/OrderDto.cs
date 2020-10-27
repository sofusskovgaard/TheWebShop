using System.Collections.Generic;

namespace TheWebShop.Common.Dtos
{
    public class OrderDto : BaseDto
    {
        public int UserEntityId { get; set; }
        
        public UserDto Customer { get; set; }
        
        public int TotalQuantity { get; set; }
        
        public decimal Total { get; set; }
        
        public decimal TotalTax { get; set; }
        
        public List<OrderItemDto> Items { get; set; }
    }
}