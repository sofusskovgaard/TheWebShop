using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models;
using TheWebShop.Services.BasketService;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.WebApp.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        private readonly IMapper _mapper;

        public ProductDetailedDto Product { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Quantity { get; set; } = 1;

        public DetailsModel(IProductService productService, IBasketService basketService, IMapper mapper)
        {
            _productService = productService;
            _basketService = basketService;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            Product = await _productService.GetById<ProductDetailedDto>(entityId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            Product = await _productService.GetById<ProductDetailedDto>(entityId);
            await _basketService.AddToBasket(HttpContext, Product, Quantity);

            return RedirectToPage(new {entityId});
        }
    }
}