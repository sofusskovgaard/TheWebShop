using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.Services.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly IProductService _productService;

        public BasketService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<BasketModel> GetBasket(HttpContext context)
        {
            var cookie = context.Request.Cookies["BASKET"];

            if (cookie != null)
            {
                var basket = JsonConvert.DeserializeObject<BasketModel>(cookie);

                foreach (var basketItem in basket.Items)
                {
                    basketItem.Product = await _productService.GetById<ProductDto>(basketItem.ProductEntityId);
                }

                return basket;
            }
            else
            {
                return new BasketModel() { Items = new List<BasketItemModel>() };
            }
        }

        public async Task<int> GetBasketCount(HttpContext context)
        {
            var basket = await GetBasket(context);

            return basket.Items.Count > 0 ? basket.Items.Sum(x => x.Quantity) : 0;
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

                if (value <= 0)
                {
                    basket.Items.RemoveAt(itemIndex);
                }
                else
                {
                    if (basket.Items[itemIndex].Product.Stock >= value)
                    {
                        basket.Items[itemIndex].Quantity = value;
                    }
                    else
                    {
                        basket.Items[itemIndex].Quantity = basket.Items[itemIndex].Product.Stock;
                    }
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
            if (Quantity <= 0)
                throw new ArgumentOutOfRangeException("Quantity", Quantity, "Quantity out of range. Should be more than 0");

            var basket = await GetBasket(context);
            var basketIndex = basket.Items.FindIndex(x => x.ProductEntityId == product.EntityId); 
                
            if (basketIndex > -1)
            {
                if (basket.Items[basketIndex].Product.Stock >= basket.Items[basketIndex].Quantity + Quantity)
                {
                    basket.Items[basketIndex].Quantity += Quantity;
                }
                else
                {
                    basket.Items[basketIndex].Quantity = basket.Items[basketIndex].Product.Stock;
                }
            }
            else
            {
                if (product.Stock >= Quantity)
                {
                    basket.Items.Add(new BasketItemModel() { ProductEntityId = product.EntityId, Quantity = Quantity });
                }
                else
                {
                    basket.Items.Add(new BasketItemModel() { ProductEntityId = product.EntityId, Quantity = product.Stock });
                }
            }
                
            context.Response.Cookies.Append("BASKET", JsonConvert.SerializeObject(basket));
        }

        public async Task ClearBasket(HttpContext context)
        {
            await Task.Run(() => context.Response.Cookies.Delete("BASKET"));
        }
    }
}