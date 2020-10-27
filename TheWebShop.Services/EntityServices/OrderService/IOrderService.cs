using TheWebShop.Common.Filters.Order;
using TheWebShop.Data.Entities.Order;

namespace TheWebShop.Services.EntityServices.OrderService
{
    public interface IOrderService : IBaseEntityService<OrderEntity, OrderFilter, OrderOrderBy>
    {
    }
}