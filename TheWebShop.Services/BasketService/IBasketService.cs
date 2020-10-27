using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models;

namespace TheWebShop.Services.BasketService
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasket(HttpContext context);

        Task<int> GetBasketCount(HttpContext context);
        
        Task<BasketModel> EditBasket(HttpContext context, IFormCollection form);

        Task SaveBasket(HttpContext context, BasketModel basket);

        Task AddToBasket(HttpContext context, ProductDto product, int Quantity);

        Task ClearBasket(HttpContext context);
    }
}