using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters;
using TheWebShop.Data.Entities;

namespace TheWebShop.Services.EntityServices
{
    public abstract class BaseEntityService<TEntity, TFilter, TEnum> : IBaseEntityService<TEntity, TFilter, TEnum>
        where TEntity : BaseEntity
        where TFilter : BaseFilter<TEnum>
        where TEnum : Enum
    {
        public abstract Task<T> GetById<T>(int entityId) where T : BaseDto;

        public abstract Task<IEnumerable<T>> GetByFilter<T>(TFilter filter) where T : BaseDto;

        public abstract Task<T> UpdateById<T>(int entityId, object data) where T : BaseDto;

        public abstract Task<T> Create<T>(TEntity entity) where T : BaseDto;

        public abstract Task<bool> DeleteById(int entityId);
    }
}
