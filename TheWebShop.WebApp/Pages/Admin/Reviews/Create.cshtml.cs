using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Common.Models.Forms;
using TheWebShop.Data.Entities.Review;
using TheWebShop.Services.EntityServices.ProductService;
using TheWebShop.Services.EntityServices.ReviewService;

namespace TheWebShop.WebApp.Pages.Admin.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly IReviewService _reviewService;

        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public SelectList Products { get; set; }

        [BindProperty]
        public ReviewFormModel FormModel { get; set; }

        public CreateModel(IReviewService reviewService, IProductService productService, IMapper mapper)
        {
            _reviewService = reviewService;
            _productService = productService;

            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            var _products = await _productService.GetByFilter<ProductDto>(new ProductFilter() { IncludeInactive = true, PrioritizeHighlighted = false });
            Products = new SelectList(_products.OrderBy(x => x.NameWithBrand), nameof(ProductDto.EntityId), nameof(ProductDto.NameWithBrand));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entity = _mapper.Map<ReviewEntity>(FormModel);
            await _reviewService.Create<ReviewDto>(entity);

            return RedirectToPage();
        }
    }
}