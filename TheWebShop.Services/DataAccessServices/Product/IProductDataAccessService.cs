using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TheWebShop.Common.Filters.Product;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Services.DataAccessServices.Product
{
    public interface IProductDataAccessService : IBaseDataAccessService<ProductEntity, ProductFilter, ProductOrderBy>
    {
    }
}
