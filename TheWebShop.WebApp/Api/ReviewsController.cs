using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Review;
using TheWebShop.Services.EntityServices.ReviewService;

namespace TheWebShop.WebApp.Api
{
    [Route("api/[controller]")]
    public class ReviewsController : BaseApiController<ReviewFilter>
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(
            IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        
        [HttpGet]
        public override async Task<IActionResult> GetByFilter([FromQuery] ReviewFilter filter)
        {
            return await this.TryAsync(async () =>
            {
                var count = await _reviewService.CountEntitiesByFilter(filter);
                Response.Headers.Add("X-Total-Items", count.ToString());
                
                return Ok(await _reviewService.GetByFilter<ReviewDto>(filter));
            });
        }

        [HttpGet("{entityId}")]
        public override async Task<IActionResult> GetById(int entityId)
        {
            return await this.TryAsync(async () => Ok(await _reviewService.GetById<ReviewDto>(entityId)));
        }

        [HttpDelete("{entityId}")]
        public override async Task<IActionResult> DeleteById(int entityId)
        {
            return await this.TryAsync(async () => Ok(await _reviewService.DeleteById(entityId)));
        }
    }
}