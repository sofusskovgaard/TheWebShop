using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheWebShop.Data.Entities.ProductPicture
{
    public class ProductPictureEntityConfiguration : BaseEntityConfiguration<ProductPictureEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductPictureEntity> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.Pictures)
                .HasForeignKey(x => x.ProductEntityId);
        }
    }
}