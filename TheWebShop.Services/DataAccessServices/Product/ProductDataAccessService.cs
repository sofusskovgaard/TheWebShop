using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TheWebShop.Common.Filters.Product;
using TheWebShop.Data;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Services.CachingServices;

namespace TheWebShop.Services.DataAccessServices.Product
{
    public class ProductDataAccessService : BaseDataAccessService<ProductEntity, ProductFilter, ProductOrderBy>, IProductDataAccessService
    {
        private readonly DatabaseContext _context;

        private readonly ICachingService _cachingService;

        public ProductDataAccessService(IDatabaseContextFactory databaseContextFactory, ICachingService cachingService)
        {
            _context = databaseContextFactory.CreateDbContext(null);
            _cachingService = cachingService;
        }

        public override async Task<ProductEntity> GetById(int entityId)
        {
            var product = await _context.Products
                .AsNoTracking()
                .Include(x => x.Pictures)
                .Include(x => x.Brand)
                .Include(x => x.Categories)
                .ThenInclude(x => x.Category)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.EntityId == entityId);

            return product;
        }

        public override async Task<IEnumerable<ProductEntity>> GetByFilter(ProductFilter filter)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Include(x => x.Pictures)
                .Include(x => x.Brand)
                .Include(x => x.Categories)
                    .ThenInclude(x => x.Category)
                .Include(x => x.Reviews)
                .FilterEntities(filter)
                .OrderEntities(filter)
                .PaginateEntities(filter)
                .ToListAsync();

            return products;
        }

        public override async Task<ProductEntity> UpdateById(int entityId, object data)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.EntityId == entityId);

            foreach (var property in product.GetType().GetProperties())
            {
                try
                {
                    var propertyValue = property.GetValue(product);
                    var updatedProperty = data.GetType().GetProperty(property.Name);
                    var updatedPropertyValue = updatedProperty.GetValue(data);

                    if (propertyValue != updatedPropertyValue)
                    {
                        property.SetValue(product, updatedPropertyValue);
                    }
                }
                catch (NullReferenceException ex)
                {

                }
            }

            await _context.SaveChangesAsync();

            return product;
        }

        public override async Task<ProductEntity> Create(ProductEntity entity)
        {
            var entry = _context.Add(entity);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public override async Task<bool> DeleteById(int entityId)
        {
            try
            {
                var product = await _context.Products
                    .Include(x => x.Pictures)
                    .Include(x => x.Reviews)
                    .Include(x => x.Categories)
                    .FirstOrDefaultAsync(x => x.EntityId == entityId);

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
