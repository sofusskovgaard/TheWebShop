using System.Threading.Tasks;

using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models;
using TheWebShop.Data.Entities.User;

namespace TheWebShop.Services.OrderingService
{
    public interface IOrderingService
    {
        Task<OrderDto> CreateOrder(BasketModel basket, UserEntity user);
    }
}
