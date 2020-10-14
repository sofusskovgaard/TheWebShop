using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using TheWebShop.Common.Filters.Product;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Services.DataAccessServices.Product;

namespace TheWebShop.WebApp.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IProductDataAccessService _productDataAccessService;

        public int TotalProducts { get; set; }
        public IEnumerable<ProductEntity> Products { get; set; }

        [BindProperty]
        public int Page { get; set; } = 1;

        [BindProperty]
        public int PageSize { get; set; } = 12;

        public IndexModel(IProductDataAccessService productDataAccessService)
        {
            _productDataAccessService = productDataAccessService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Products = await _productDataAccessService.GetByFilter(new ProductFilter() { Page = Page, PageSize = PageSize });
            TotalProducts = await _productDataAccessService.CountEntitiesByFiter(new ProductFilter() { Page = Page, PageSize = PageSize });

            return Page();
        }
    }
}
