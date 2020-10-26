using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Common.Models.Forms;
using TheWebShop.Services.EntityServices.BrandService;
using TheWebShop.Services.EntityServices.ProductService;
using TheWebShop.Services.EntityServices.ReviewService;

namespace TheWebShop.WebApp.Pages.Admin.Reviews
{
    public class EditModel : PageModel
    {
        private readonly IReviewService _reviewService;

        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public ReviewDetailedDto Review { get; set; }
        
        public SelectList Products { get; set; }

        [BindProperty]
        public ReviewFormModel FormModel { get; set; }

        public EditModel(IReviewService reviewService, IProductService productService, IMapper mapper)
        {
            _reviewService = reviewService;
            _productService = productService;

            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            Review = await _reviewService.GetById<ReviewDetailedDto>(entityId);
            var _products = await _productService.GetByFilter<ProductDto>(new ProductFilter() { IncludeInactive = true, PrioritizeHighlighted = false });
            Products = new SelectList(_products.OrderBy(x => x.NameWithBrand), nameof(ProductDto.EntityId), nameof(ProductDto.NameWithBrand));

            FormModel = _mapper.Map<ReviewFormModel>(Review);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _reviewService.UpdateById<ReviewDto>(entityId, FormModel);

            return RedirectToPage();
        }
    }
}