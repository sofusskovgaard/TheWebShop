using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheWebShop.Common.Filters;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Services.DataAccessServices.Product
{
    public static class ProductDataAccessExtensions
    {
        public static IQueryable<ProductEntity> FilterEntities(
            this IQueryable<ProductEntity> entities, ProductFilter filter
        )
        {
            var filteredEntities = entities;

            if (!filter.IncludeOutOfStock)
                filteredEntities = filteredEntities.Where(x => x.Stock > 0);

            if (!string.IsNullOrEmpty(filter.Query))
            {
                filteredEntities = filteredEntities.Where(x => x.Name.ToLower().Contains(filter.Query.ToLower()));
            }

            if (filter.Brand != null)
            {
                filteredEntities =
                    filteredEntities.Where(
                        x => x.Brand.EntityId == filter.Brand
                    );
            }

            if (filter.Category != null)
            {
                filteredEntities =
                    filteredEntities.Where(
                        x => x.Categories.Any(
                            c => c.CategoryEntityId == filter.Category
                        )
                    );
            }

            if (filter.MinPrice != null)
            {
                filteredEntities = filteredEntities.Where(x => x.Price >= filter.MinPrice);
            }

            if (filter.MaxPrice != null)
            {
                filteredEntities = filteredEntities.Where(x => x.Price <= filter.MaxPrice);
            }

            if (filter.MinRating != null)
            {
                filteredEntities = filteredEntities.Where(
                    x => x.Reviews.Sum(r => r.Rating) / x.Reviews.Count >= filter.MinRating
                );
            }

            if (filter.MaxRating != null)
            {
                filteredEntities = filteredEntities.Where(
                    x => x.Reviews.Sum(r => r.Rating) / x.Reviews.Count <= filter.MaxRating
                );
            }

            return filteredEntities;
        }

        public static IQueryable<ProductEntity> OrderEntities(
            this IQueryable<ProductEntity> entities, ProductFilter filter
        )
        {
            switch (filter.OrderBy)
            {
                case ProductOrderBy.None:
                    return entities;

                case ProductOrderBy.NameAsc:
                    return entities.OrderByDescending(x => x.Highlight).ThenBy(x => x.Name);

                case ProductOrderBy.NameDesc:
                    return entities.OrderByDescending(x => x.Highlight).ThenByDescending(x => x.Name);

                case ProductOrderBy.ReviewsAsc:
                    return entities
                        .OrderBy(x => x.Highlight)
                        .ThenBy(x => x.Reviews.Sum(r => r.Rating) / x.Reviews.Count)
                        .ThenByDescending(x => x.Reviews.Count)
                        .ThenByDescending(x => x.CreatedAt);

                case ProductOrderBy.ReviewsDesc:
                    return entities
                        .OrderByDescending(x => x.Highlight)
                        .ThenByDescending(x => x.Reviews.Sum(r => r.Rating) / x.Reviews.Count)
                        .ThenByDescending(x => x.Reviews.Count)
                        .ThenByDescending(x => x.CreatedAt);

                case ProductOrderBy.PriceAsc:
                    return entities.OrderByDescending(x => x.Highlight).ThenBy(x => x.Price);

                case ProductOrderBy.PriceDesc:
                    return entities.OrderByDescending(x => x.Highlight).ThenByDescending(x => x.Price);

                case ProductOrderBy.CreatedAtAsc:
                    return entities.OrderByDescending(x => x.Highlight).ThenBy(x => x.CreatedAt);

                case ProductOrderBy.CreatedAtDesc:
                    return entities.OrderByDescending(x => x.Highlight).ThenByDescending(x => x.CreatedAt);

                default:
                    throw new ArgumentOutOfRangeException(nameof(filter.OrderBy), filter.OrderBy, null);
            }
        }

        public static IQueryable<ProductEntity> PaginateEntities(
            this IQueryable<ProductEntity> entities, ProductFilter filter
        )
        {
            return filter.PageSize == 0
                ? entities
                : entities.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);
        }
    }
}