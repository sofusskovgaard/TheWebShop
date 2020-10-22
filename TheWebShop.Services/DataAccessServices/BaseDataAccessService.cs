using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TheWebShop.Common.Filters;
using TheWebShop.Data;
using TheWebShop.Data.Entities;

namespace TheWebShop.Services.DataAccessServices
{
    public abstract class BaseDataAccessService<TEntity, TFilter, TEnum> : IBaseDataAccessService<TEntity, TFilter, TEnum>
        where TEntity : BaseEntity
        where TFilter : BaseFilter<TEnum>
        where TEnum : Enum
    {
        public abstract Task<TEntity> GetById(int entityId);

        public abstract Task<IEnumerable<TEntity>> GetByFilter(TFilter filter);

        public abstract Task<TEntity> UpdateById(int entityId, object data);

        public abstract Task<TEntity> Create(TEntity entity);

        public abstract Task<bool> DeleteById(int entityId);

        public abstract Task<int> CountEntitiesByFilter(TFilter filter);
    }
}
