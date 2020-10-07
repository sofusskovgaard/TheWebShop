using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TheWebShop.Data.Entities;

namespace TheWebShop.Services.DataAccessServices
{
    public interface IBaseDataAccessService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int entityId);

        Task<IEnumerable<TEntity>> GetByFilter();

        Task<TEntity> UpdateById();

        Task<bool> DeleteById();
    }
}
