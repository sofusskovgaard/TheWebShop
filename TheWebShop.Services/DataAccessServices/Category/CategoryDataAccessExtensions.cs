using System;
using System.Linq;

using TheWebShop.Common.Filters.Category;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Data.Entities.Category;

namespace TheWebShop.Services.DataAccessServices.Category
{
    public static class CategoryDataAccessExtensions
    {
        public static IQueryable<CategoryEntity> FilterEntities(
            this IQueryable<CategoryEntity> entities, CategoryFilter filter
        )
        {
            var filteredEntities = entities;

            if (!string.IsNullOrEmpty(filter.Query))
            {
                filteredEntities = filteredEntities.Where(x => x.Name.ToLower().Contains(filter.Query.ToLower()));
            }

            return filteredEntities;
        }

        public static IQueryable<CategoryEntity> OrderEntities(
            this IQueryable<CategoryEntity> entities, CategoryFilter filter
        )
        {
            switch (filter.OrderBy)
            {
                case CategoryOrderBy.None:
                    return entities;

                default:
                    throw new ArgumentOutOfRangeException(nameof(filter.OrderBy), filter.OrderBy, null);
            }
        }

        public static IQueryable<CategoryEntity> PaginateEntities(
            this IQueryable<CategoryEntity> entities, CategoryFilter filter
        )
        {
            return entities.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);
        }
    }
}