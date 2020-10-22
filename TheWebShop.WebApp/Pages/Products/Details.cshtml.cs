using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheWebShop.Common.Dtos;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.WebApp.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;

        private readonly IMapper _mapper;
        
        public ProductDetailedDto Product { get; set; }

        public DetailsModel(IProductService productService, IMapper mapper)
        {
            _productService = productService;

            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            Product = await _productService.GetById<ProductDetailedDto>(entityId);

            return Page();
        }
    }
}