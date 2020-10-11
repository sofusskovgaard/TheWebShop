# Entities

Der er 6 forskellige slags entities

- `BrandEntity`

  ```csharp
  [Table("Brands")]
  public class BrandEntity : BaseEntity, IBrandEntity
  {
      public string Name { get; set; }

      public double Rating => RatingCount > 0 ? RatingCount / Products.SelectMany(x => x.Reviews).Sum(x => x.Rating) : 0;

      public int RatingCount => Products.SelectMany(x => x.Reviews).Count();

      public ICollection<ProductEntity> Products { get; set; }
  }
  ```

- `CategoryEntity`

  ```csharp
  [Table("Categories")]
  public class CategoryEntity : BaseEntity, ICategoryEntity
  {
      public string Name { get; set; }

      public string Description { get; set; }

      public int? ParentCategoryEntityId { get; set; }

      public CategoryEntity ParentCategory { get; set; }

      public ICollection<CategoryEntity> ChildCategories { get; set; }

      public ICollection<ProductCategoryEntity> Products { get; set; }
  }
  ```

- `ProductEntity`

  ```csharp
  [Table("Products")]
  public class ProductEntity : BaseEntity, IProductEntity
  {
      public string Name { get; set; }

      public int? BrandEntityId { get; set; }

      public BrandEntity Brand { get; set; }

      [Column("decimal(5,2)")]
      public double Price { get; set; }

      public ICollection<ProductPictureEntity> Pictures { get; set; }

      public ICollection<ProductCategoryEntity> Categories { get; set; }

      public double Rating => RatingCount > 0 ? Reviews.Sum(x => x.Rating) / RatingCount : 0;

      public int RatingCount => Reviews.Count;

      public ICollection<ReviewEntity> Reviews { get; set; }
  }
  ```

- `ProductCategoryEntity`

  ```csharp
  [Table("ProductCategories")]
  public class ProductCategoryEntity : BaseEntity, IProductCategoryEntity
  {
      public int? ProductEntityId { get; set; }

      public ProductEntity Product { get; set; }

      public int? CategoryEntityId { get; set; }

      public CategoryEntity Category { get; set; }
  }
  ```

- `ProductPictureEntity`

  ```csharp
  [Table("ProductPictures")]
  public class ProductPictureEntity : BaseEntity, IProductPictureEntity
  {
      public int? ProductEntityId { get; set; }

      public ProductEntity Product { get; set; }

      public string Caption { get; set; }

      public byte[] Picture { get; set; }
  }
  ```

- `ReviewEntity`

  ```csharp
  [Table("Reviews")]
  public class ReviewEntity : BaseEntity, IReviewEntity
  {
      public int Rating { get; set; }

      public string Title { get; set; }

      public string Comment { get; set; }

      public int ProductEntityId { get; set; }

      public ProductEntity Product { get; set; }
  }
  ```

Alle entities er baseret på `BaseEntity` klassen. `BaseEntity` er en abstrakt klasse som bruges til at bygge entities ud fra. Alle entities har nogle fælles properties.

```csharp
public abstract class BaseEntity : IBaseEntity
{
    [Key]
    public int EntityId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}
```
