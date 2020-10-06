using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheWebShop.Data.Entities.Brand
{
    public class BrandEntityConfiguration : BaseEntityConfiguration<BrandEntity>
    {
        public override void Configure(EntityTypeBuilder<BrandEntity> builder)
        {
            base.Configure(builder);

            builder
                .HasMany(x => x.Products)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandEntityId);
        }
    }
}