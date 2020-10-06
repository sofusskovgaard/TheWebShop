using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Data.Entities.ProductCategory;

namespace TheWebShop.Data.Entities.Category
{
    public class CategoryEntity : BaseEntity, ICategoryEntity
    {
        public string Name { get; set; }

        public int? ParentCategoryEntityId { get; set; }

        public CategoryEntity ParentCategory { get; set; }

        public ICollection<CategoryEntity> ChildCategories { get; set; }

        public ICollection<ProductCategoryEntity> Products { get; set; }
    }
}
