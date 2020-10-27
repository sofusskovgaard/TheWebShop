using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models;
using TheWebShop.Services.BasketService;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.WebApp.Pages
{
    public class BasketModel : PageModel
    {
        private readonly IProductService _productService;

        private readonly IBasketService _basketService;

        public Common.Models.BasketModel Basket { get; set; } = new Common.Models.BasketModel();

        [BindProperty] public int ProductToBeRemoved { get; set; }

        public BasketModel(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
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
    }
}