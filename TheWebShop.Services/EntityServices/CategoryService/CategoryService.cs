using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TheWebShop.Common.Filters.Category;
using TheWebShop.Data.Entities.Category;
using TheWebShop.Services.DataAccessServices.Category;

namespace TheWebShop.Services.EntityServices.CategoryService
{
    public class CategoryService : BaseEntityService<CategoryEntity, CategoryFilter, CategoryOrderBy>, ICategoryService
    {
        private readonly ICategoryDataAccessService _categoryDataAccessService;

        private readonly IMapper _mapper;

        public CategoryService(ICategoryDataAccessService categoryDataAccessService, IMapper mapper)
        {
            _categoryDataAccessService = categoryDataAccessService;
            _mapper = mapper;
        }
        
        public override async Task<T> GetById<T>(int entityId)
        {
            var entity = await _categoryDataAccessService.GetById(entityId);
            return _mapper.Map<T>(entity);
        }

        public override async Task<IEnumerable<T>> GetByFilter<T>(CategoryFilter filter)
        {
            var entities = await _categoryDataAccessService.GetByFilter(filter);
            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public override async Task<T> UpdateById<T>(int entityId, object data)
        {
            var entity = await _categoryDataAccessService.UpdateById(entityId, data);
            return _mapper.Map<T>(entity);
        }

        public override async Task<T> Create<T>(CategoryEntity entity)
        {
            var newEntity = await _categoryDataAccessService.Create(entity);
            return _mapper.Map<T>(newEntity);
        }

        public override async Task<bool> DeleteById(int entityId)
        {
            return await _categoryDataAccessService.DeleteById(entityId);
        }

        public override async Task<int> CountEntitiesByFilter(CategoryFilter filter)
        {
            return await _categoryDataAccessService.CountEntitiesByFilter(filter);
        }
    }
}