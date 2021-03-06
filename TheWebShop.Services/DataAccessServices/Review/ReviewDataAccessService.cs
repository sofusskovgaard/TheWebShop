﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TheWebShop.Common.Filters.Review;
using TheWebShop.Data;
using TheWebShop.Data.Entities.Review;

namespace TheWebShop.Services.DataAccessServices.Review
{
    public class ReviewDataAccessService : BaseDataAccessService<ReviewEntity, ReviewFilter, ReviewOrderBy>, IReviewDataAccessService
    {
        private readonly DatabaseContext _context;

        public ReviewDataAccessService(IDatabaseContextFactory databaseContextFactory)
        {
            this._context = databaseContextFactory.CreateDbContext(null);
        }

        public override async Task<ReviewEntity> GetById(int entityId)
        {
            var review = await _context.Reviews
                .AsNoTracking()
                .Include(x => x.Product)
                    .ThenInclude(x => x.Brand)
                .FirstOrDefaultAsync(x => x.EntityId == entityId);

            return review;
        }

        public override async Task<IEnumerable<ReviewEntity>> GetByFilter(ReviewFilter filter)
        {
            var reviews = await _context.Reviews
                .AsNoTracking()
                .Include(x => x.Product)
                    .ThenInclude(x => x.Brand)
                .FilterEntities(filter)
                .OrderEntities(filter)
                .PaginateEntities(filter)
                .ToListAsync();

            return reviews;
        }

        public override async Task<ReviewEntity> UpdateById(int entityId, object data)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.EntityId == entityId);

            foreach (var property in review.GetType().GetProperties())
            {
                try
                {
                    var propertyValue = property.GetValue(review);
                    var updatedProperty = data.GetType().GetProperty(property.Name);
                    var updatedPropertyValue = updatedProperty.GetValue(data);

                    if (propertyValue != updatedPropertyValue)
                    {
                        property.SetValue(review, updatedPropertyValue);
                    }
                }
                catch (NullReferenceException ex)
                {

                }
            }

            await _context.SaveChangesAsync();

            return review;
        }

        public override async Task<ReviewEntity> Create(ReviewEntity entity)
        {
            var entry = _context.Add(entity);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public override async Task<bool> DeleteById(int entityId)
        {
            try
            {
                var review = await _context.Reviews
                    .Include(x => x.Product)
                    .FirstOrDefaultAsync(x => x.EntityId == entityId);

                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<int> CountEntitiesByFilter(ReviewFilter filter)
        {
            return await _context.Reviews
                .AsNoTracking()
                .FilterEntities(filter)
                .CountAsync();
        }
    }
}