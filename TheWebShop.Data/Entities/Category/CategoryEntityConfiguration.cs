using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheWebShop.Data.Entities.Category
{
    public class CategoryEntityConfiguration : BaseEntityConfiguration<CategoryEntity>
    {
        public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(x => x.ParentCategory)
                .WithMany(x => x.ChildCategories)
                .HasForeignKey(x => x.ParentCategoryEntityId);

            builder
                .HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryEntityId);
        }
    }
}