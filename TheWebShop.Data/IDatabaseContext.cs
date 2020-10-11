using Microsoft.EntityFrameworkCore;

using TheWebShop.Data.Entities.Brand;
using TheWebShop.Data.Entities.Category;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Data.Entities.ProductCategory;
using TheWebShop.Data.Entities.ProductPicture;
using TheWebShop.Data.Entities.Review;

namespace TheWebShop.Data
{
    public interface IDatabaseContext
    {
        DbSet<BrandEntity> Brands { get; set; }

        DbSet<CategoryEntity> Categories { get; set; }

        DbSet<ProductEntity> Products { get; set; }

        DbSet<ReviewEntity> Reviews { get; set; }

        DbSet<ProductCategoryEntity> ProductCategories { get; set; }

        DbSet<ProductPictureEntity> ProductPictures { get; set; }
    }
}