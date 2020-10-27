using System;
using System.Linq;
using TheWebShop.Common.Filters.Order;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Data.Entities.Order;

namespace TheWebShop.Services.DataAccessServices.Order
{
    public static class OrderDataAccessExtensions
    {
        public static IQueryable<OrderEntity> FilterEntities(
            this IQueryable<OrderEntity> entities, OrderFilter filter
        )
        {
            var filteredEntities = entities;

            return filteredEntities;
        }

        public static IQueryable<OrderEntity> OrderEntities(
            this IQueryable<OrderEntity> entities, OrderFilter filter
        )
        {
            switch (filter.OrderBy)
            {
                case OrderOrderBy.None:
                    return entities;

                case OrderOrderBy.PriceAsc:
                    return entities.OrderBy(x => x.Total);

                case OrderOrderBy.PriceDesc:
                    return entities.OrderByDescending(x => x.Total);

                case OrderOrderBy.ProductsAsc:
                    return entities.OrderBy(x => x.Items.Sum(x => x.Quantity));

                case OrderOrderBy.ProductsDesc:
                    return entities.OrderByDescending(x => x.Items.Sum(x => x.Quantity));

                case OrderOrderBy.CreatedAtAsc:
                    return entities.OrderBy(x => x.CreatedAt);

                case OrderOrderBy.CreatedAtDesc:
                    return entities.OrderByDescending(x => x.CreatedAt);

                default:
                    throw new ArgumentOutOfRangeException(nameof(filter.OrderBy), filter.OrderBy, null);
            }
        }

        public static IQueryable<OrderEntity> PaginateEntities(
            this IQueryable<OrderEntity> entities, OrderFilter filter
        )
        {
            return filter.PageSize == 0
                ? entities
                : entities.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);
        }
    }
}