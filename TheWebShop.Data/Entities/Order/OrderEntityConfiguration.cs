using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWebShop.Data.Entities.OrderItem;
using TheWebShop.Data.Entities.User;

namespace TheWebShop.Data.Entities.Order
{
    public class OrderEntityConfiguration : BaseEntityConfiguration<OrderEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            base.Configure(builder);

            builder
                .HasMany<OrderItemEntity>(x => x.Items)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderEntityId);

            builder
                .HasOne<UserEntity>(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserEntityId);
        }
    }
}