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
                filteredEntities = filteredEntities.Where(x => x.Name.ToLower().Contains(filter.Query.ToLower()));

            if (filter.Parent != null)
                filteredEntities = filteredEntities.Where(x => x.ParentCategoryEntityId == filter.Parent);

            return filteredEntities;
        }

        public static IQueryable<CategoryEntity> OrderEntities(
            this IQueryable<CategoryEntity> entities, CategoryFilter filter
        )
        {
            var orderedEntities = entities.Where(x => x.Active);

            if (filter.IncludeInactive)
                orderedEntities = entities;
                
            switch (filter.OrderBy)
            {
                case CategoryOrderBy.None:
                    return orderedEntities;

                case CategoryOrderBy.NameAsc:
                    return orderedEntities.OrderBy(x => x.Name);

                case CategoryOrderBy.NameDesc:
                    return orderedEntities.OrderByDescending(x => x.Name);

                case CategoryOrderBy.ProductsAsc:
                    return orderedEntities.OrderBy(x => x.Products.Count);

                case CategoryOrderBy.ProductsDesc:
                    return orderedEntities.OrderByDescending(x => x.Products.Count);
                
                case CategoryOrderBy.CreatedAtAsc:
                    return orderedEntities.OrderBy(x => x.CreatedAt);

                case CategoryOrderBy.CreatedAtDesc:
                    return orderedEntities.OrderByDescending(x => x.CreatedAt);

                default:
                    throw new ArgumentOutOfRangeException(nameof(filter.OrderBy), filter.OrderBy, null);
            }
        }

        public static IQueryable<CategoryEntity> PaginateEntities(
            this IQueryable<CategoryEntity> entities, CategoryFilter filter
        )
        {
            return filter.PageSize == 0 ? entities : entities.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);
        }
    }
}