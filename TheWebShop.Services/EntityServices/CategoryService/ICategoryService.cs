using TheWebShop.Common.Filters.Category;
using TheWebShop.Data.Entities.Category;

namespace TheWebShop.Services.EntityServices.CategoryService
{
    public interface ICategoryService : IBaseEntityService<CategoryEntity, CategoryFilter, CategoryOrderBy>
    {
    }
}