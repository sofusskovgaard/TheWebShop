using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Brand;
using TheWebShop.Common.Filters.Category;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Services.EntityServices.BrandService;
using TheWebShop.Services.EntityServices.CategoryService;
using TheWebShop.Services.EntityServices.ProductService;
using TheWebShop.WebApp.Models;

namespace TheWebShop.WebApp.Pages.Products
{
    public class IndexModel : BasePaginatedPage
    {
        private readonly IProductService _productService;

        private readonly IBrandService _brandService;

        private readonly ICategoryService _categoryService;
        
        public IEnumerable<ProductWithPicturesDto> Products { get; set; }
        
        public IEnumerable<CategoryDto> Categories { get; set; }
        
        public IEnumerable<BrandDto> Brands { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public ProductFilter Filter { get; set; }

        public IndexModel(IProductService productService, IBrandService brandService, ICategoryService categoryService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            SetPreexistingFilters();
            Filter.Page = p;
            Filter.PageSize = ps;

            Products = await _productService.GetByFilter<ProductWithPicturesDto>(Filter);
            Brands = await _brandService.GetByFilter<BrandDto>(new BrandFilter() { OrderBy = BrandOrderBy.NameAsc });
            Categories = await _categoryService.GetByFilter<CategoryDto>(new CategoryFilter() { OrderBy = CategoryOrderBy.NameAsc });
            TotalResults = await _productService.CountEntitiesByFilter(Filter);

            return Page();
        }
    }
}