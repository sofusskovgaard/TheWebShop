using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Services.DataAccessServices.Product;
using TheWebShop.Services.EntityServices.ProductService;
using TheWebShop.WebApp.Models;

namespace TheWebShop.WebApp.Pages.Admin.Products
{
    public class IndexModel : BasePaginatedPage
    {
        private readonly IProductService _productService;

        public IEnumerable<ProductDto> Products { get; set; }

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var filter = new ProductFilter() { Page = p, PageSize = ps };
            
            Products = await _productService.GetByFilter<ProductDto>(filter);
            TotalResults = await _productService.CountEntitiesByFilter(filter);

            return Page();
        }
    }
}
