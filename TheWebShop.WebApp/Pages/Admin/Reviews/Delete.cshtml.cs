using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheWebShop.Common.Dtos;
using TheWebShop.Services.EntityServices.BrandService;
using TheWebShop.Services.EntityServices.ReviewService;

namespace TheWebShop.WebApp.Pages.Admin.Reviews
{
    public class DeleteModel : PageModel
    {
        private readonly IReviewService _reviewService;

        public ReviewDto Review { get; set; }

        public DeleteModel(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            Review = await _reviewService.GetById<ReviewDto>(entityId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            await _reviewService.DeleteById(entityId);
            return RedirectToPage("Index");
        }
    }
}