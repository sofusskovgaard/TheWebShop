using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Common.Models.Components;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IEnumerable<ProductWithPicturesDto> NewestProducts { get; set; }
        
        public IEnumerable<ProductWithPicturesDto> MostPopularProducts { get; set; }


        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            NewestProducts = await _productService.GetByFilter<ProductWithPicturesDto>(new ProductFilter() { OrderBy = ProductOrderBy.CreatedAtDesc, PrioritizeHighlighted = false, PageSize = 4 });
            
            MostPopularProducts = await _productService.GetByFilter<ProductWithPicturesDto>(new ProductFilter() { OrderBy = ProductOrderBy.ReviewsDesc, PrioritizeHighlighted = false, PageSize = 4 });
            
            return Page();
        }
    }
}
