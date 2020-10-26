using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.WebApp.Pages
{
    public class BasketModel : PageModel
    {
        private readonly IProductService _productService;

        public Common.Models.BasketModel Basket { get; set; } = new Common.Models.BasketModel();

        [BindProperty]
        public int ProductToBeRemoved { get; set; }

        public BasketModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var basketCookie = Request.Cookies["BASKET"];
            
            if (basketCookie != null)
                Basket = JsonConvert.DeserializeObject<Common.Models.BasketModel>(basketCookie);

            foreach (var item in Basket.Items)
            {
                item.Product = await _productService.GetById<ProductDto>(item.ProductEntityId);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return await Task.Run(() =>
            {
                var basketCookie = Request.Cookies["BASKET"];

                if (basketCookie != null)
                    Basket = JsonConvert.DeserializeObject<Common.Models.BasketModel>(basketCookie);

                foreach (var item in Request.Form)
                {

                    if (!int.TryParse(item.Key, out int key) || !int.TryParse(item.Value, out int value))
                        continue;

                    var itemIndex = Basket.Items.FindIndex(x => x.ProductEntityId == key);

                    if (itemIndex < 0)
                        continue;

                    if (value == 0)
                    {
                        Basket.Items.RemoveAt(itemIndex);
                    }
                    else
                    {
                        Basket.Items[itemIndex].Quantity = Convert.ToInt32(item.Value);
                    }
                }

                Response.Cookies.Append("BASKET", JsonConvert.SerializeObject(Basket));

                return RedirectToPage();
            });
        }

        public async Task<IActionResult> OnPostRemoveProduct()
        {
            return await Task.Run(() =>
            {
                var basketCookie = Request.Cookies["BASKET"];

                if (basketCookie != null)
                    Basket = JsonConvert.DeserializeObject<Common.Models.BasketModel>(basketCookie);

                Basket.Items.RemoveAt(Basket.Items.FindIndex(x => x.ProductEntityId == ProductToBeRemoved));

                Response.Cookies.Append("BASKET", JsonConvert.SerializeObject(Basket));

                return RedirectToPage();
            });
        }
    }
}
