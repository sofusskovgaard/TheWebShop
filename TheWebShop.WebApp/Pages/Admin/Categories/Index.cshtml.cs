using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Category;
using TheWebShop.Services.EntityServices.CategoryService;
using TheWebShop.WebApp.Models;

namespace TheWebShop.WebApp.Pages.Admin.Categories
{
    public class IndexModel : BasePaginatedPage
    {
        private readonly ICategoryService _categoryService;

        public IEnumerable<CategoryDto> Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public CategoryFilter Filter { get; set; }

        public Stopwatch Stopwatch { get; set; }

        public IndexModel(ICategoryService reviewService)
        {
            _categoryService = reviewService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Stopwatch = Stopwatch.StartNew();

            SetPreexistingFilters();
            Filter.Page = p;
            Filter.PageSize = ps;
            Filter.IncludeInactive = true;

            Categories = await _categoryService.GetByFilter<CategoryDto>(Filter);
            TotalResults = await _categoryService.CountEntitiesByFilter(Filter);

            Stopwatch.Stop();
            return Page();
        }
    }
}