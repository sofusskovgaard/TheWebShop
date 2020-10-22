using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheWebShop.Common.Dtos;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.WebApp.Pages.Admin.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _productService;
        
        public ProductDto Product { get; set; }

        public DeleteModel(IProductService productService)
        {
            _productService = productService;
        }
        
        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            Product = await _productService.GetById<ProductDto>(entityId);
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            await _productService.DeleteById(entityId);
            return RedirectToPage("/Admin/Products/Index");
        }
    }
}