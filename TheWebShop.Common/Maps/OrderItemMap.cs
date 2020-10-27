using AutoMapper;
using TheWebShop.Common.Dtos;
using TheWebShop.Data.Entities.OrderItem;

namespace TheWebShop.Common.Maps
{
    public class OrderItemMap : Profile
    {
        public OrderItemMap()
        {
            CreateMap<OrderItemEntity, OrderItemDto>()
                .ReverseMap();
        }
    }
}