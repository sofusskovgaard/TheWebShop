using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TheWebShop.Common.Filters.Product;
using TheWebShop.Data;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Services.DataAccessServices.Product
{
    public class ProductDataAccessService : BaseDataAccessService<ProductEntity, ProductFilter, ProductOrderBy>
    {
        private readonly DatabaseContext _context;

        public ProductDataAccessService(DatabaseContextFactory databaseContextFactory)
        {
            this._context = databaseContextFactory.CreateDbContext(null);
        }

        public override async Task<ProductEntity> GetById(int entityId)
        {
            var product = await _context.Products
                              .AsNoTracking()
                              .FirstOrDefaultAsync(x => x.EntityId == entityId);

            return product;
        }

        public override async Task<IEnumerable<ProductEntity>> GetByFilter(ProductFilter filter)
        {
            var products = await _context.Products
                .AsNoTracking()
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

        public override async Task<bool> DeleteById(int entityId)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.EntityId == entityId);

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
