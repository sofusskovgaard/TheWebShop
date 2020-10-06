using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TheWebShop.Data.Entities;

namespace TheWebShop.Data.EntityConfigurations
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd();

            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
