using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Category;
using TheWebShop.Common.Models.Forms;
using TheWebShop.Data.Entities.Category;
using TheWebShop.Services.EntityServices.CategoryService;

namespace TheWebShop.WebApp.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public SelectList Categories { get; set; }

        [BindProperty]
        public CategoryFormModel FormModel { get; set; }

        public CreateModel(ICategoryService reviewService, IMapper mapper)
        {
            _categoryService = reviewService;

            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            var _categories = await _categoryService.GetByFilter<CategoryDto>(new CategoryFilter() { IncludeInactive = true });
            Categories = new SelectList(_categories.OrderBy(x => x.Name), nameof(CategoryDto.EntityId), nameof(CategoryDto.Name));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            if (!ModelState.IsValid)
            {
                return await OnGetAsync(entityId);
            }

            var entity = _mapper.Map<CategoryEntity>(FormModel);
            await _categoryService.Create<CategoryDto>(entity);

            return RedirectToPage();
        }
    }
}