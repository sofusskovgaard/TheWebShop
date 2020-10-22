using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TheWebShop.Common.Filters.Product;
using TheWebShop.Data;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Data.Entities.ProductPicture;
using TheWebShop.Services.CachingServices;

namespace TheWebShop.Services.DataAccessServices.Product
{
    public class ProductDataAccessService : BaseDataAccessService<ProductEntity, ProductFilter, ProductOrderBy>, IProductDataAccessService
    {
        private readonly DatabaseContext _context;

        public ProductDataAccessService(IDatabaseContextFactory databaseContextFactory)
        {
            _context = databaseContextFactory.CreateDbContext(null);
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
            var product = await _context.Products
                .Include(x => x.Pictures)
                .Include(x => x.Brand)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.EntityId == entityId);

            foreach (var property in data.GetType().GetProperties())
            {
                try
                {
                    var propertyValue = property.GetValue(data);
                    var oldProperty = product.GetType().GetProperty(property.Name);
                    var oldPropertyValue = oldProperty.GetValue(product);

                    if (propertyValue != oldPropertyValue)
                    {
                        oldProperty.SetValue(product, propertyValue);
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

        public override async Task<int> CountEntitiesByFilter(ProductFilter filter)
        {
            return await _context.Products
                .AsNoTracking()
                .FilterEntities(filter)
                .CountAsync();
        }


        public async Task<IEnumerable<ProductPictureEntity>> GetPicturesForProduct(int entityId)
        {
            return await _context.ProductPictures
                .AsNoTracking()
                .Where(x => x.ProductEntityId == entityId)
                .ToListAsync();
        }

        public async Task<bool> UploadPictures(int entityId, IEnumerable<ProductPictureEntity> productPictures)
        {
            try
            {
                var product = await _context.Products.FindAsync(entityId);

                if (product.Pictures == null)
                    product.Pictures = new List<ProductPictureEntity>();
                
                foreach (var productPicture in productPictures)
                {
                    product.Pictures.Add(productPicture);
                }

                await _context.SaveChangesAsync();
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeletePictureById(int entityId)
        {
            try
            {
                var product = await _context.ProductPictures.FindAsync(entityId);
                
                _context.ProductPictures.Remove(product);

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
