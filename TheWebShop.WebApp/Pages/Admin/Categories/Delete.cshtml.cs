using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheWebShop.Common.Dtos;
using TheWebShop.Services.EntityServices.CategoryService;

namespace TheWebShop.WebApp.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public CategoryDto Category { get; set; }

        public DeleteModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            Category = await _categoryService.GetById<CategoryDto>(entityId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            await _categoryService.DeleteById(entityId);
            return RedirectToPage("Index");
        }
    }
}