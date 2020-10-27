using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models;
using TheWebShop.Data.Entities.User;
using TheWebShop.Services.BasketService;
using TheWebShop.Services.EntityServices.ProductService;
using TheWebShop.Services.OrderingService;

namespace TheWebShop.WebApp.Pages
{
    public class BasketModel : PageModel
    {
        private readonly SignInManager<UserEntity> _singInManager;

        private readonly UserManager<UserEntity> _userManager;

        private readonly IProductService _productService;

        private readonly IBasketService _basketService;

        private readonly IOrderingService _orderingService;

        public Common.Models.BasketModel Basket { get; set; } = new Common.Models.BasketModel();

        [BindProperty]
        public int ProductToBeRemoved { get; set; }

        public BasketModel(
            IProductService productService,
            IBasketService basketService,
            IOrderingService orderingService,
            SignInManager<UserEntity> signInManager,
            UserManager<UserEntity> userManager
        )
        {
            _productService = productService;
            _basketService = basketService;
            _orderingService = orderingService;

            _singInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Basket = await _basketService.GetBasket(HttpContext);

            foreach (var item in Basket.Items)
            {
                item.Product = await _productService.GetById<ProductDto>(item.ProductEntityId);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Basket = await _basketService.EditBasket(HttpContext, Request.Form);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostClearBasketAsync()
        {
            await _basketService.ClearBasket(HttpContext);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostPlaceOrderAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var order = await _orderingService.CreateOrder(await _basketService.GetBasket(HttpContext), user);
            await _basketService.ClearBasket(HttpContext);

            return RedirectToPage("/Order", new {OrderId = order.EntityId});
        }
    }
}