using TheWebShop.Common.Filters.Brand;
using TheWebShop.Data.Entities.Brand;

namespace TheWebShop.Services.DataAccessServices.Brand
{
    public interface IBrandDataAccessService : IBaseDataAccessService<BrandEntity, BrandFilter, BrandOrderBy>
    {
    }
}