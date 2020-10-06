using TheWebShop.Data.Entities.Category;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.ProductCategory
{
    public interface IProductCategoryEntity : IBaseEntity
    {
        int? ProductEntityId { get; set; }

        ProductEntity Product { get; set; }

        int? CategoryEntityId { get; set; }

        CategoryEntity Category { get; set; }
    }
}