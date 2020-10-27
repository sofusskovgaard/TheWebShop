using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWebShop.Data.Entities.Order;

namespace TheWebShop.Data.Entities.User
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public virtual void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasMany<OrderEntity>(x => x.Orders)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.UserEntityId);
        }
    }
}