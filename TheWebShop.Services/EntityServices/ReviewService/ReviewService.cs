using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TheWebShop.Common.Filters.Review;
using TheWebShop.Data.Entities.Review;
using TheWebShop.Services.DataAccessServices.Review;

namespace TheWebShop.Services.EntityServices.ReviewService
{
    public class ReviewService : BaseEntityService<ReviewEntity, ReviewFilter, ReviewOrderBy>, IReviewService
    {
        private readonly IReviewDataAccessService _reviewDataAccessService;
        
        private readonly IMapper _mapper;

        public ReviewService(IReviewDataAccessService reviewDataAccessService, IMapper mapper)
        {
            _reviewDataAccessService = reviewDataAccessService;

            _mapper = mapper;
        }
        
        public override async Task<T> GetById<T>(int entityId)
        {
            var entity = await _reviewDataAccessService.GetById(entityId);
            return _mapper.Map<T>(entity);
        }

        public override async Task<IEnumerable<T>> GetByFilter<T>(ReviewFilter filter)
        {
            var entities = await _reviewDataAccessService.GetByFilter(filter);
            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public override async Task<T> UpdateById<T>(int entityId, object data)
        {
            var entity = await _reviewDataAccessService.UpdateById(entityId, data);
            return _mapper.Map<T>(entity);
        }

        public override async Task<T> Create<T>(ReviewEntity entity)
        {
            var newEntity = await _reviewDataAccessService.Create(entity);
            return _mapper.Map<T>(newEntity);
        }

        public override async Task<bool> DeleteById(int entityId)
        {
            return await _reviewDataAccessService.DeleteById(entityId);
        }

        public override async Task<int> CountEntitiesByFilter(ReviewFilter filter)
        {
            return await _reviewDataAccessService.CountEntitiesByFilter(filter);
        }
    }
}