using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Brand;
using TheWebShop.Services.EntityServices.BrandService;
using TheWebShop.WebApp.Models;

namespace TheWebShop.WebApp.Pages.Admin.Brands
{
    public class IndexModel : BasePaginatedPage
    {
        private readonly IBrandService _brandService;

        public IEnumerable<BrandDto> Brands { get; set; }

        [BindProperty(SupportsGet = true)]
        public BrandFilter Filter { get; set; }

        public Stopwatch Stopwatch { get; set; }

        public IndexModel(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Stopwatch = Stopwatch.StartNew();

            SetPreexistingFilters();
            Filter.Page = p;
            Filter.PageSize = ps;
            Filter.IncludeInactive = true;

            Brands = await _brandService.GetByFilter<BrandDto>(Filter);
            TotalResults = await _brandService.CountEntitiesByFilter(Filter);

            Stopwatch.Stop();
            return Page();
        }
    }
}
