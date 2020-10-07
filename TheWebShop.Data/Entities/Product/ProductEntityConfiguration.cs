using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TheWebShop.Data.Entities.Brand;

namespace TheWebShop.Data.Entities.Product
{
    public class ProductEntityConfiguration : BaseEntityConfiguration<ProductEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(x => x.Brand)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.BrandEntityId);

            builder
                .HasMany(x => x.Pictures)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductEntityId);

            builder
                .HasMany(x => x.Categories)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductEntityId);

            builder
                .HasMany(x => x.Reviews)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductEntityId);
        }
    }
}