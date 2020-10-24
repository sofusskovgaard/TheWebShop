using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Category;
using TheWebShop.Common.Models.Forms;
using TheWebShop.Services.EntityServices.CategoryService;

namespace TheWebShop.WebApp.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public CategoryDto Category { get; set; }
        
        public SelectList Categories { get; set; }

        [BindProperty]
        public CategoryFormModel FormModel { get; set; }

        public EditModel(ICategoryService reviewService, IMapper mapper)
        {
            _categoryService = reviewService;

            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            Category = await _categoryService.GetById<CategoryDto>(entityId);
            var _categories = await _categoryService.GetByFilter<CategoryDto>(new CategoryFilter() { IncludeInactive = true });
            Categories = new SelectList(_categories.OrderBy(x => x.Name), nameof(CategoryDto.EntityId), nameof(CategoryDto.Name));

            FormModel = _mapper.Map<CategoryFormModel>(Category);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _categoryService.UpdateById<CategoryDto>(entityId, FormModel);

            return RedirectToPage();
        }
    }
}