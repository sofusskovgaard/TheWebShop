using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TheWebShop.Common.Filters.Product;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Services.EntityServices.ProductService
{
    public class ProductService : BaseEntityService<ProductEntity, ProductFilter, ProductOrderBy>
    {
        public override Task<T> GetById<T>(int entityId)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<T>> GetByFilter<T>(ProductFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Task<T> UpdateById<T>(int entityId, object data)
        {
            throw new NotImplementedException();
        }

        public override Task<T> Create<T>(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteById(int entityId)
        {
            throw new NotImplementedException();
        }
    }
}
