using TheWebShop.Common.Filters.Order;
using TheWebShop.Data.Entities.Order;

namespace TheWebShop.Services.DataAccessServices.Order
{
    public interface IOrderDataAccessService : IBaseDataAccessService<OrderEntity, OrderFilter, OrderOrderBy>
    {
        
    }
}