using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Review;
using TheWebShop.Services.EntityServices.ReviewService;
using TheWebShop.WebApp.Models;

namespace TheWebShop.WebApp.Pages.Admin.Reviews
{
    public class IndexModel : BasePaginatedPage
    {
        private readonly IReviewService _reviewService;

        public IEnumerable<ReviewDetailedDto> Reviews { get; set; }

        [BindProperty(SupportsGet = true)]
        public ReviewFilter Filter { get; set; }

        public Stopwatch Stopwatch { get; set; }

        public IndexModel(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Stopwatch = Stopwatch.StartNew();

            SetPreexistingFilters();
            Filter.Page = p;
            Filter.PageSize = ps;
            Filter.IncludeInactive = true;

            Reviews = await _reviewService.GetByFilter<ReviewDetailedDto>(Filter);
            TotalResults = await _reviewService.CountEntitiesByFilter(Filter);

            Stopwatch.Stop();
            return Page();
        }
    }
}