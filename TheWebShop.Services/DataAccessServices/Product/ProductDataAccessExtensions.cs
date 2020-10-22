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

            if (!filter.IncludeInactive) 
                filteredEntities = filteredEntities.Where(x => x.Active);

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

            if (filter.PrioritizeHighlighted)
            {
                var orderedEntities = entities.OrderByDescending(x => x.Highlight);

                switch (filter.OrderBy)
                {
                    case ProductOrderBy.None:
                        break;

                    case ProductOrderBy.NameAsc:
                        orderedEntities = orderedEntities.ThenBy(x => x.Name);
                        break;

                    case ProductOrderBy.NameDesc:
                        orderedEntities = orderedEntities.ThenByDescending(x => x.Name);
                        break;

                    case ProductOrderBy.ReviewsAsc:
                        orderedEntities = orderedEntities
                            .ThenBy(x => x.Reviews.Sum(r => r.Rating) / x.Reviews.Count)
                            .ThenByDescending(x => x.Reviews.Count)
                            .ThenByDescending(x => x.CreatedAt);
                        break;

                    case ProductOrderBy.ReviewsDesc:
                        orderedEntities = orderedEntities.ThenByDescending(x => x.Reviews.Sum(r => r.Rating) / x.Reviews.Count)
                            .ThenByDescending(x => x.Reviews.Count)
                            .ThenByDescending(x => x.CreatedAt);
                        break;

                    case ProductOrderBy.PriceAsc:
                        orderedEntities = orderedEntities.ThenBy(x => x.Price);
                        break;

                    case ProductOrderBy.PriceDesc:
                        orderedEntities = orderedEntities.ThenByDescending(x => x.Price);
                        break;

                    case ProductOrderBy.CreatedAtAsc:
                        orderedEntities = orderedEntities.ThenBy(x => x.CreatedAt);
                        break;

                    case ProductOrderBy.CreatedAtDesc:
                        orderedEntities = orderedEntities.ThenByDescending(x => x.CreatedAt);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(filter.OrderBy), filter.OrderBy, null);
                }

                return orderedEntities;
            }
            else
            {
                var orderedEntities = entities;

                switch (filter.OrderBy)
                {
                    case ProductOrderBy.None:
                        break;

                    case ProductOrderBy.NameAsc:
                        orderedEntities = orderedEntities.OrderBy(x => x.Name);
                        break;

                    case ProductOrderBy.NameDesc:
                        orderedEntities = orderedEntities.OrderByDescending(x => x.Name);
                        break;

                    case ProductOrderBy.ReviewsAsc:
                        orderedEntities = orderedEntities
                            .OrderBy(x => x.Reviews.Sum(r => r.Rating) / x.Reviews.Count)
                            .ThenByDescending(x => x.Reviews.Count)
                            .ThenByDescending(x => x.CreatedAt);
                        break;

                    case ProductOrderBy.ReviewsDesc:
                        orderedEntities = orderedEntities
                            .OrderByDescending(x => x.Reviews.Sum(r => r.Rating) / x.Reviews.Count)
                            .ThenByDescending(x => x.Reviews.Count)
                            .ThenByDescending(x => x.CreatedAt);
                        break;

                    case ProductOrderBy.PriceAsc:
                        orderedEntities = orderedEntities.OrderBy(x => x.Price);
                        break;

                    case ProductOrderBy.PriceDesc:
                        orderedEntities = orderedEntities.OrderByDescending(x => x.Price);
                        break;

                    case ProductOrderBy.CreatedAtAsc:
                        orderedEntities = orderedEntities.OrderBy(x => x.CreatedAt);
                        break;

                    case ProductOrderBy.CreatedAtDesc:
                        orderedEntities = orderedEntities.OrderByDescending(x => x.CreatedAt);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(filter.OrderBy), filter.OrderBy, null);
                }

                return orderedEntities;
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