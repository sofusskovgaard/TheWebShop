using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheWebShop.Common.Filters.Brand;
using TheWebShop.Common.Filters.Category;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Common.Filters.Review;
using TheWebShop.Data.Entities.Brand;
using TheWebShop.Data.Entities.Category;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Data.Entities.Review;
using TheWebShop.Services.DataAccessServices.Brand;
using TheWebShop.Services.DataAccessServices.Category;
using TheWebShop.Services.DataAccessServices.Product;
using TheWebShop.Services.DataAccessServices.Review;
using TheWebShop.WebApp.Models;

namespace TheWebShop.WebApp.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IProductDataAccessService _productDataAccessService;

        private readonly IBrandDataAccessService _brandDataAccessService;

        private readonly IReviewDataAccessService _reviewDataAccessService;

        private readonly ICategoryDataAccessService _categoryDataAccessService;

        public int ProductCount { get; set; }
        public IEnumerable<ProductEntity> Products { get; set; }

        public int BrandCount { get; set; }
        public IEnumerable<BrandEntity> Brands { get; set; }

        public int ReviewCount { get; set; }
        public IEnumerable<ReviewEntity> Reviews { get; set; }

        public int CategoryCount { get; set; }
        public IEnumerable<CategoryEntity> Categories { get; set; }

        public IndexModel(
            IProductDataAccessService productDataAccessService,
            IBrandDataAccessService brandDataAccessService,
            IReviewDataAccessService reviewDataAccessService,
            ICategoryDataAccessService categoryDataAccessService)
        {
            _productDataAccessService = productDataAccessService;
            _brandDataAccessService = brandDataAccessService;
            _reviewDataAccessService = reviewDataAccessService;
            _categoryDataAccessService = categoryDataAccessService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ProductCount = await _productDataAccessService.CountEntitiesByFilter(new ProductFilter());
            Products = await _productDataAccessService.GetByFilter(new ProductFilter());

            BrandCount = await _brandDataAccessService.CountEntitiesByFilter(new BrandFilter());
            Brands = await _brandDataAccessService.GetByFilter(new BrandFilter());

            ReviewCount = await _reviewDataAccessService.CountEntitiesByFilter(new ReviewFilter());
            Reviews = await _reviewDataAccessService.GetByFilter(new ReviewFilter());

            CategoryCount = await _categoryDataAccessService.CountEntitiesByFilter(new CategoryFilter());
            Categories = await _categoryDataAccessService.GetByFilter(new CategoryFilter());

            return Page();
        }
    }
}
