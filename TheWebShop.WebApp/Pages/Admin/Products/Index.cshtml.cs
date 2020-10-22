using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Brand;
using TheWebShop.Common.Filters.Category;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Services.DataAccessServices.Product;
using TheWebShop.Services.EntityServices.BrandService;
using TheWebShop.Services.EntityServices.CategoryService;
using TheWebShop.Services.EntityServices.ProductService;
using TheWebShop.WebApp.Models;

namespace TheWebShop.WebApp.Pages.Admin.Products
{
    public class IndexModel : BasePaginatedPage
    {
        private readonly IProductService _productService;

        private readonly IBrandService _brandService;

        private readonly ICategoryService _categoryService;

        public IEnumerable<ProductDto> Products { get; set; }

        public SelectList Brands { get; set; }

        public SelectList Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public ProductFilter Filter { get; set; }

        public Stopwatch Stopwatch { get; set; }

        public IndexModel(IProductService productService, IBrandService brandService, ICategoryService categoryService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Stopwatch = Stopwatch.StartNew();

            SetPreexistingFilters();
            Filter.Page = p;
            Filter.PageSize = ps;
            Filter.PrioritizeHighlighted = false;
            Filter.IncludeInactive = true;

            Products = await _productService.GetByFilter<ProductDto>(Filter);
            TotalResults = await _productService.CountEntitiesByFilter(Filter);

            Brands = new SelectList(await _brandService.GetByFilter<BrandDto>(new BrandFilter() { PageSize = 0 }), nameof(BrandDto.EntityId), nameof(BrandDto.Name));
            Categories = new SelectList(await _categoryService.GetByFilter<CategoryDto>(new CategoryFilter() { PageSize = 0 }), nameof(CategoryDto.EntityId), nameof(CategoryDto.Name));

            Stopwatch.Stop();
            return Page();
        }
    }
}
