using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheWebShop.Data.Entities.ProductCategory
{
    public class ProductCategoryEntityConfiguration : BaseEntityConfiguration<ProductCategoryEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryEntityId);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.ProductEntityId);
        }
    }
}