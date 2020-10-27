using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models;

namespace TheWebShop.Services.BasketService
{
    public class BasketService : IBasketService
    {
        public async Task<BasketModel> GetBasket(HttpContext context)
        {
            return await Task.Run(() =>
            {
                var cookie = context.Request.Cookies["BASKET"];

                if (cookie != null)
                {
                    var basket = JsonConvert.DeserializeObject<BasketModel>(cookie); 
                                                                 
                    return basket;                                                   
                }
                else
                {
                    return new BasketModel() {Items = new List<BasketItemModel>()};
                }
            });
        }

        public async Task<int> GetBasketCount(HttpContext context)
        {
            return await Task.Run(() =>
            {
                var cookie = context.Request.Cookies["BASKET"];

                if (cookie != null)
                {
                    var basket = JsonConvert.DeserializeObject<BasketModel>(cookie);

                    return basket.Items.Sum(x => x.Quantity);    
                }

                return 0;
            });
        }

        public async Task<BasketModel> EditBasket(HttpContext context, IFormCollection form)
        {
            var basket = await GetBasket(context);
            
            foreach (var item in form)
            {
                if (!int.TryParse(item.Key, out int key) || !int.TryParse(item.Value, out int value))
                    continue;

                var itemIndex = basket.Items.FindIndex(x => x.ProductEntityId == key);

                if (itemIndex < 0)
                    continue;

                if (value == 0)
                {
                    basket.Items.RemoveAt(itemIndex);
                }
                else
                {
                    basket.Items[itemIndex].Quantity = Convert.ToInt32(item.Value);
                }
            }

            await SaveBasket(context, basket);
            return basket;
        }

        public async Task SaveBasket(HttpContext context, BasketModel basket)
        {
            await Task.Run(() =>
            {
                var cookie = JsonConvert.SerializeObject(basket);
                context.Response.Cookies.Append("BASKET", cookie);
            });
        }

        public async Task AddToBasket(HttpContext context, ProductDto product, int Quantity = 1)
        {
            var basket = await GetBasket(context);
            var basketIndex = basket.Items.FindIndex(x => x.ProductEntityId == product.EntityId); 
                
            if (basketIndex > -1)
            {
                basket.Items[basketIndex].Quantity += Quantity;
            }
            else
            {
                basket.Items.Add(new BasketItemModel() { ProductEntityId = product.EntityId, Quantity = Quantity });
            }
                
            context.Response.Cookies.Append("BASKET", JsonConvert.SerializeObject(basket));
        }

        public async Task ClearBasket(HttpContext context)
        {
            await Task.Run(() => context.Response.Cookies.Delete("BASKET"));
        }
    }
}