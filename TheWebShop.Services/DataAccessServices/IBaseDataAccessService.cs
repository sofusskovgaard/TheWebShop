using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TheWebShop.Common.Filters;
using TheWebShop.Data.Entities;

namespace TheWebShop.Services.DataAccessServices
{
    public interface IBaseDataAccessService<TEntity, TFilter, TEnum>
        where TEntity : BaseEntity
        where TFilter : BaseFilter<TEnum>
        where TEnum : Enum
    {
        Task<TEntity> GetById(int entityId);

        Task<IEnumerable<TEntity>> GetByFilter(TFilter filter);

        Task<TEntity> UpdateById(int entityId, object data);

        Task<TEntity> Create(TEntity entity);

        Task<bool> DeleteById(int entityId);

        Task<int> CountEntitiesByFiter(TFilter filter);
    }
}
