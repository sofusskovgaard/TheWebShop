using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWebShop.Data.Entities.Order;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.OrderItem
{
    public class OrderItemEntityConfiguration : BaseEntityConfiguration<OrderItemEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
            base.Configure(builder);

            builder
                .HasOne<OrderEntity>(x => x.Order)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.OrderEntityId);

            builder.HasOne<ProductEntity>(x => x.Product);
        }
    }
}