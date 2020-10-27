using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheWebShop.Common.Filters.Order;
using TheWebShop.Data;
using TheWebShop.Data.Entities.Order;

namespace TheWebShop.Services.DataAccessServices.Order
{
    public class OrderDataAccessService : BaseDataAccessService<OrderEntity, OrderFilter, OrderOrderBy>
    {
        private readonly DatabaseContext _context;

        public OrderDataAccessService(IDatabaseContextFactory databaseContextFactory)
        {
            _context = databaseContextFactory.CreateDbContext(null);
        }
        
        public override async Task<OrderEntity> GetById(int entityId)
        {
            var order = await _context.Orders
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Items)
                    .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.EntityId == entityId);

            return order;
        }

        public override async Task<IEnumerable<OrderEntity>> GetByFilter(OrderFilter filter)
        {
            var orders = await _context.Orders
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Items)
                    .ThenInclude(x => x.Product)
                .FilterEntities(filter)
                .OrderEntities(filter)
                .PaginateEntities(filter)
                .ToListAsync();

            return orders;
        }

        public override async Task<OrderEntity> UpdateById(int entityId, object data)
        {
            var order = await _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.EntityId == entityId);

            foreach (var property in data.GetType().GetProperties())
            {
                try
                {
                    var propertyValue = property.GetValue(data);
                    var oldProperty = order.GetType().GetProperty(property.Name);
                    var oldPropertyValue = oldProperty.GetValue(order);

                    if (propertyValue != oldPropertyValue)
                    {
                        oldProperty.SetValue(order, propertyValue);
                    }
                }
                catch (NullReferenceException ex)
                {
                    
                }
            }

            await _context.SaveChangesAsync();

            return order;
        }

        public override async Task<OrderEntity> Create(OrderEntity entity)
        {
            var entry = _context.Add(entity);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public override async Task<bool> DeleteById(int entityId)
        {
            try
            {
                var order = await _context.Orders
                    .Include(x => x.Customer)
                    .FirstOrDefaultAsync(x => x.EntityId == entityId);

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<int> CountEntitiesByFilter(OrderFilter filter)
        {
            return await _context.Orders
                .AsNoTracking()
                .FilterEntities(filter)
                .CountAsync();
        }
    }
}