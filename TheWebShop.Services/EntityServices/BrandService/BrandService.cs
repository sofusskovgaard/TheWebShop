using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TheWebShop.Common.Filters.Brand;
using TheWebShop.Data.Entities.Brand;
using TheWebShop.Services.DataAccessServices.Brand;

namespace TheWebShop.Services.EntityServices.BrandService
{
    public class BrandService : BaseEntityService<BrandEntity, BrandFilter, BrandOrderBy>, IBrandService
    {
        private readonly IBrandDataAccessService _brandDataAccessService;

        private readonly IMapper _mapper;

        public BrandService(IBrandDataAccessService brandDataAccessService, IMapper mapper)
        {
            _brandDataAccessService = brandDataAccessService;

            _mapper = mapper;
        }
        
        public override async Task<T> GetById<T>(int entityId)
        {
            var entity = await _brandDataAccessService.GetById(entityId);
            return _mapper.Map<T>(entity);
        }

        public override async Task<IEnumerable<T>> GetByFilter<T>(BrandFilter filter)
        {
            var entities = await _brandDataAccessService.GetByFilter(filter);
            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public override async Task<T> UpdateById<T>(int entityId, object data)
        {
            var entity = await _brandDataAccessService.UpdateById(entityId, data);
            return _mapper.Map<T>(entity);
        }

        public override async Task<T> Create<T>(BrandEntity entity)
        {
            var newEntity = await _brandDataAccessService.Create(entity);
            return _mapper.Map<T>(newEntity);
        }

        public override async Task<bool> DeleteById(int entityId)
        {
            return await _brandDataAccessService.DeleteById(entityId);
        }

        public override async Task<int> CountEntitiesByFilter(BrandFilter filter)
        {
            return await _brandDataAccessService.CountEntitiesByFilter(filter);
        }
    }
}