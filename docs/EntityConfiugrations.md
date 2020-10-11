# Entity Configurations

Man kan have ret mange entities som skal konfigureres, det vil ofte resultere i en uoverskueligt `DbContext`. Jeg benytter mig derfor af `IEntityTypeConfiguration<>` interfacet i en `BaseEntityConfiguration<TEntity>`.

```csharp
public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd();

        builder.Property(x => x.UpdatedAt).HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnAddOrUpdate();

        builder.Property(x => x.RowVersion).IsRowVersion();
    }
}
```
