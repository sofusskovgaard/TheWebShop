using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters;
using TheWebShop.Data.Entities;

namespace TheWebShop.Services.EntityServices
{
    public interface IBaseEntityService<TEntity, TFilter, TEnum>
        where TEntity : BaseEntity
        where TFilter : BaseFilter<TEnum>
        where TEnum : Enum
    {
        Task<T> GetById<T>(int entityId) where T : BaseDto;

        Task<IEnumerable<T>> GetByFilter<T>(TFilter filter) where T : BaseDto;

        Task<T> UpdateById<T>(int entityId, object data) where T : BaseDto;

        Task<T> Create<T>(TEntity entity) where T : BaseDto;

        Task<bool> DeleteById(int entityId);
    }
}
