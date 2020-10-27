using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models;
using TheWebShop.Data.Entities.Order;
using TheWebShop.Data.Entities.OrderItem;
using TheWebShop.Data.Entities.User;
using TheWebShop.Services.EmailService;
using TheWebShop.Services.EntityServices.OrderService;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.Services.OrderingService
{
    public class OrderingService : IOrderingService
    {
        private readonly UserManager<UserEntity> _userManager;

        private readonly IOrderService _orderService;

        private readonly IProductService _productService;

        private readonly IEmailService _emailService;

        public OrderingService(UserManager<UserEntity>  userManager, IOrderService orderService, IProductService productService, IEmailService emailService)
        {
            _userManager = userManager;
            _orderService = orderService;
            _productService = productService;
            _emailService = emailService;
        }

        public async Task<OrderDto> CreateOrder(BasketModel basket, UserEntity user)
        {
            var orderEntity = new OrderEntity();

            foreach (var basketItem in basket.Items)
            {
                var product = await _productService.GetById<ProductDto>(basketItem.ProductEntityId);

                orderEntity.Items.Add(new OrderItemEntity()
                {
                    Quantity = basketItem.Quantity,
                    ProductEntityId = basketItem.ProductEntityId,
                    PricePerProduct = product.Price,
                    Total = basketItem.Quantity * product.Price
                });

                await _productService.UpdateById<ProductDto>(basketItem.ProductEntityId, new { Stock = product.Stock - basketItem.Quantity });
            }

            orderEntity.UserEntityId = user.Id;
            orderEntity.TotalQuantity = orderEntity.Items.Sum(x => x.Quantity);
            orderEntity.Total = orderEntity.Items.Sum(x => x.Total);
            orderEntity.TotalTax = orderEntity.Total * 0.25M;

            var result = await _orderService.Create<OrderDto>(orderEntity);

            await _emailService.SendEmailAsync(user.Email, $"New Order - {orderEntity.EntityId}", "Yay you just made an order. YAY!");

            return result;
        }
    }
}
