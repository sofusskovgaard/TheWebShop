using System;
using System.Linq;

using TheWebShop.Common.Filters.Product;
using TheWebShop.Common.Filters.Review;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Data.Entities.Review;

namespace TheWebShop.Services.DataAccessServices.Review
{
    public static class ReviewDataAccessExtensions
    {
        public static IQueryable<ReviewEntity> FilterEntities(
           this IQueryable<ReviewEntity> entities, ReviewFilter filter
       )
        {
            var filteredEntities = entities;

            if (!string.IsNullOrEmpty(filter.Query))
            {
                filteredEntities = filteredEntities.Where(x => x.Title.ToLower().Contains(filter.Query.ToLower()));
            }

            if (filter.Product != null)
            {
                filteredEntities = filteredEntities.Where(
                    x => x.ProductEntityId == filter.Product
                );
            }

            if (filter.MinRating != null)
            {
                filteredEntities = filteredEntities.Where(
                    x => x.Rating >= filter.MinRating
                );
            }

            if (filter.MaxRating != null)
            {
                filteredEntities = filteredEntities.Where(
                    x => x.Rating <= filter.MaxRating
                );
            }

            return filteredEntities;
        }

        public static IQueryable<ReviewEntity> OrderEntities(
            this IQueryable<ReviewEntity> entities, ReviewFilter filter
        )
        {
            var orderedProducts = entities.Where(x => x.Active);

            if (filter.IncludeInactive)
                orderedProducts = entities;
                
            switch (filter.OrderBy)
            {
                case ReviewOrderBy.None:
                    return orderedProducts;

                case ReviewOrderBy.RatingAsc:
                    return orderedProducts.OrderBy(x => x.Rating).ThenByDescending(x => x.CreatedAt);

                case ReviewOrderBy.RatingDesc:
                    return orderedProducts.OrderByDescending(x => x.Rating).ThenByDescending(x => x.CreatedAt);
                
                case ReviewOrderBy.CreatedAtAsc:
                    return orderedProducts.OrderBy(x => x.CreatedAt);

                case ReviewOrderBy.CreatedAtDesc:
                    return orderedProducts.OrderByDescending(x => x.CreatedAt);

                default:
                    throw new ArgumentOutOfRangeException(nameof(filter.OrderBy), filter.OrderBy, null);
            }
        }

        public static IQueryable<ReviewEntity> PaginateEntities(
            this IQueryable<ReviewEntity> entities, ReviewFilter filter
        )
        {
            return filter.PageSize == 0 ? entities : entities.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);
        }
    }
}