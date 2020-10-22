using TheWebShop.Common.Filters.Brand;
using TheWebShop.Data.Entities.Brand;

namespace TheWebShop.Services.EntityServices.BrandService
{
    public interface IBrandService : IBaseEntityService<BrandEntity, BrandFilter, BrandOrderBy>
    {
    }
}