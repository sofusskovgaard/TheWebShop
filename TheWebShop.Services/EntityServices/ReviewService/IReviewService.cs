using TheWebShop.Common.Filters.Review;
using TheWebShop.Data.Entities.Review;

namespace TheWebShop.Services.EntityServices.ReviewService
{
    public interface IReviewService : IBaseEntityService<ReviewEntity, ReviewFilter, ReviewOrderBy>
    {
    }
}