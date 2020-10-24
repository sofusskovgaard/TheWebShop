using System;
using System.Linq;

using TheWebShop.Common.Filters.Brand;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Data.Entities.Brand;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Services.DataAccessServices.Brand
{
    public static class BrandDataAccessExtensions
    {
        public static IQueryable<BrandEntity> FilterEntities(
            this IQueryable<BrandEntity> entities, BrandFilter filter
        )
        {
            var filteredEntities = entities;

            if (!string.IsNullOrEmpty(filter.Query))
            {
                filteredEntities = filteredEntities.Where(x => x.Name.ToLower().Contains(filter.Query.ToLower()));
            }

            return filteredEntities;
        }

        public static IQueryable<BrandEntity> OrderEntities(
            this IQueryable<BrandEntity> entities, BrandFilter filter
        )
        {
            var orderedEntities = entities.Where(x => x.Active);

            if (filter.IncludeInactive)
                orderedEntities = entities;
            
            switch (filter.OrderBy)
            {
                case BrandOrderBy.None:
                    return orderedEntities;

                case BrandOrderBy.NameAsc:
                    return orderedEntities.OrderBy(x => x.Name);

                case BrandOrderBy.NameDesc:
                    return orderedEntities.OrderByDescending(x => x.Name);

                case BrandOrderBy.ProductsAsc:
                    return orderedEntities.OrderBy(x => x.Products.Count);

                case BrandOrderBy.ProductsDesc:
                    return orderedEntities.OrderByDescending(x => x.Products.Count);
                
                case BrandOrderBy.CreatedAtAsc:
                    return orderedEntities.OrderBy(x => x.CreatedAt);

                case BrandOrderBy.CreatedAtDesc:
                    return orderedEntities.OrderByDescending(x => x.CreatedAt);

                default:
                    throw new ArgumentOutOfRangeException(nameof(filter.OrderBy), filter.OrderBy, null);
            }
        }

        public static IQueryable<BrandEntity> PaginateEntities(
            this IQueryable<BrandEntity> entities, BrandFilter filter
        )
        {
            return filter.PageSize == 0 ? entities : entities.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);
        }
    }
}