using TheWebShop.Common.Filters.Review;
using TheWebShop.Data.Entities.Review;

namespace TheWebShop.Services.DataAccessServices.Review
{
    public interface IReviewDataAccessService : IBaseDataAccessService<ReviewEntity, ReviewFilter, ReviewOrderBy>
    {
        
    }
}