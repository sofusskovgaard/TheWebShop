using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TheWebShop.Common.Filters.Brand;
using TheWebShop.Data;
using TheWebShop.Data.Entities.Brand;

namespace TheWebShop.Services.DataAccessServices.Brand
{
    public class BrandDataAccessService : BaseDataAccessService<BrandEntity, BrandFilter, BrandOrderBy>, IBrandDataAccessService
    {
        private readonly DatabaseContext _context;

        public BrandDataAccessService(IDatabaseContextFactory databaseContextFactory)
        {
            this._context = databaseContextFactory.CreateDbContext(null);
        }

        public override async Task<BrandEntity> GetById(int entityId)
        {
            var brand = await _context.Brands
                .AsNoTracking()
                .Include(x => x.Products)
                    .ThenInclude(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.EntityId == entityId);

            return brand;
        }

        public override async Task<IEnumerable<BrandEntity>> GetByFilter(BrandFilter filter)
        {
            var brands = await _context.Brands
                .AsNoTracking()
                .Include(x => x.Products)
                    .ThenInclude(x => x.Reviews)
                .FilterEntities(filter)
                .OrderEntities(filter)
                .PaginateEntities(filter)
                .ToListAsync();

            return brands;
        }

        public override async Task<BrandEntity> UpdateById(int entityId, object data)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.EntityId == entityId);

            foreach (var property in brand.GetType().GetProperties())
            {
                try
                {
                    var propertyValue = property.GetValue(brand);
                    var updatedProperty = data.GetType().GetProperty(property.Name);
                    var updatedPropertyValue = updatedProperty.GetValue(data);

                    if (propertyValue != updatedPropertyValue)
                    {
                        property.SetValue(brand, updatedPropertyValue);
                    }
                }
                catch (NullReferenceException ex)
                {

                }
            }

            await _context.SaveChangesAsync();

            return brand;
        }

        public override async Task<BrandEntity> Create(BrandEntity entity)
        {
            var entry = _context.Add(entity);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public override async Task<bool> DeleteById(int entityId)
        {
            try
            {
                var brand = await _context.Brands.FirstOrDefaultAsync(x => x.EntityId == entityId);

                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<int> CountEntitiesByFiter(BrandFilter filter)
        {
            return await _context.Brands
                .AsNoTracking()
                .FilterEntities(filter)
                .CountAsync();
        }
    }
}