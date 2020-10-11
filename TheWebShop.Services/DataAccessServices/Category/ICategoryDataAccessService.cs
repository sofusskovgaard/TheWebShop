using TheWebShop.Common.Filters.Category;
using TheWebShop.Data.Entities.Category;

namespace TheWebShop.Services.DataAccessServices.Category
{
    public interface ICategoryDataAccessService : IBaseDataAccessService<CategoryEntity, CategoryFilter, CategoryOrderBy>
    {
    }
}