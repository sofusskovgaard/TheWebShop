using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TheWebShop.Common.Filters.Category;
using TheWebShop.Data;
using TheWebShop.Data.Entities.Category;

namespace TheWebShop.Services.DataAccessServices.Category
{
    public class CategoryDataAccessService : BaseDataAccessService<CategoryEntity, CategoryFilter, CategoryOrderBy>, ICategoryDataAccessService
    {
        private readonly DatabaseContext _context;

        public CategoryDataAccessService(IDatabaseContextFactory databaseContextFactory)
        {
            this._context = databaseContextFactory.CreateDbContext(null);
        }

        public override async Task<CategoryEntity> GetById(int entityId)
        {
            var category = await _context.Categories
                .AsNoTracking()
                .Include(x => x.ChildCategories)
                .Include(x => x.ParentCategory)
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.EntityId == entityId);

            return category;
        }

        public override async Task<IEnumerable<CategoryEntity>> GetByFilter(CategoryFilter filter)
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .Include(x => x.ChildCategories)
                .Include(x => x.ParentCategory)
                .Include(x => x.Products)
                .FilterEntities(filter)
                .OrderEntities(filter)
                .PaginateEntities(filter)
                .ToListAsync();

            return categories;
        }

        public override async Task<CategoryEntity> UpdateById(int entityId, object data)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.EntityId == entityId);

            foreach (var property in category.GetType().GetProperties())
            {
                try
                {
                    var propertyValue = property.GetValue(category);
                    var updatedProperty = data.GetType().GetProperty(property.Name);
                    var updatedPropertyValue = updatedProperty.GetValue(data);

                    if (propertyValue != updatedPropertyValue)
                    {
                        property.SetValue(category, updatedPropertyValue);
                    }
                }
                catch (NullReferenceException ex)
                {

                }
            }

            await _context.SaveChangesAsync();

            return category;
        }

        public override async Task<CategoryEntity> Create(CategoryEntity entity)
        {
            var entry = _context.Add(entity);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public override async Task<bool> DeleteById(int entityId)
        {
            try
            {
                var category = await _context.Categories
                    .Include(x => x.ChildCategories)
                    .Include(x => x.ParentCategory)
                    .Include(x => x.Products)
                    .FirstOrDefaultAsync(x => x.EntityId == entityId);

                _context.Categories.Remove(category);
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