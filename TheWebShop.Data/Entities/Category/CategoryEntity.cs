using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using TheWebShop.Data.Entities.ProductCategory;

namespace TheWebShop.Data.Entities.Category
{
    [Table("Categories")]
    public class CategoryEntity : BaseEntity, ICategoryEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentCategoryEntityId { get; set; }

        public CategoryEntity ParentCategory { get; set; }

        public ICollection<CategoryEntity> ChildCategories { get; set; }

        public int ChildCategoriesCount => ChildCategories?.Count ?? 0;

        public ICollection<ProductCategoryEntity> Products { get; set; }

        public int ProductCount => Products?.Count ?? 0;
    }
}
