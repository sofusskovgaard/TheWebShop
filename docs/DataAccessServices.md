# Data Access Services

Alle data access services er baseret på en `BaseDataAccessService<TEntity, TFilter, TEnum>` klasse. På denne måde behøver jeg ikke definere de samme metoder til hver entity typer.

Ønsker du rå entities skal data access service's bruges.

Dette er koden for `BaseDataAccessService<TEntity, TFilter, TEnum>` klassen.

```csharp
public abstract class BaseDataAccessService<TEntity, TFilter, TEnum> : IBaseDataAccessService<TEntity, TFilter, TEnum>
    where TEntity : BaseEntity
    where TFilter : BaseFilter<TEnum>
    where TEnum : Enum
{
    public abstract Task<TEntity> GetById(int entityId);

    public abstract Task<IEnumerable<TEntity>> GetByFilter(TFilter filter);

    public abstract Task<TEntity> UpdateById(int entityId, object data);

    public abstract Task<TEntity> Create(TEntity entity);

    public abstract Task<bool> DeleteById(int entityId);
}
```

## Entities

### `BrandEntityConfiguration`

```csharp
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
```

### `CategoryEntityConfiguration`

```csharp
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
```

### `ProductEntityConfiguration`

```csharp
public class ProductEntityConfiguration : BaseEntityConfiguration<ProductEntity>
{
    public override void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        base.Configure(builder);

        builder.Ignore(x => x.Rating);

        builder.Ignore(x => x.RatingCount);

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
```

### `ProductCategoryEntityConfiguration`

```csharp
public class ProductCategoryEntityConfiguration : BaseEntityConfiguration<ProductCategoryEntity>
{
    public override void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
    {
        base.Configure(builder);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryEntityId);

        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.ProductEntityId);
    }
}
```

### `ProductPictureEntityConfiguration`

```csharp
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
```

### `ReviewEntityConfiguration`

```csharp
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
```
