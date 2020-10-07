using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TheWebShop.Data.Entities;

namespace TheWebShop.Services.DataAccessServices
{
    public abstract class BaseDataAccessService<TEntity> : IBaseDataAccessService<TEntity> where TEntity : BaseEntity
    {
        public abstract Task<TEntity> GetById(int entityId);

        public abstract Task<IEnumerable<TEntity>> GetByFilter();

        public abstract Task<TEntity> UpdateById();

        public abstract Task<bool> DeleteById();
    }
}
