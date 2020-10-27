using AutoMapper;
using TheWebShop.Common.Dtos;
using TheWebShop.Data.Entities.Order;

namespace TheWebShop.Common.Maps
{
    public class OrderMap : Profile
    {
        public OrderMap()
        {
            CreateMap<OrderEntity, OrderDto>()
                .ReverseMap();
        }
    }
}