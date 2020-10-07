using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheWebShop.Data.Entities.Review
{
    public class ReviewEntityConfiguration : BaseEntityConfiguration<ReviewEntity>
    {
        public override void Configure(EntityTypeBuilder<ReviewEntity> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ProductEntityId);
        }
    }
}