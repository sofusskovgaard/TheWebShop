using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheWebShop.Data.Entities
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Configure entity using the EntityTypeBuilder.
        /// </summary>
        /// <param name="builder"></param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd();

            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
