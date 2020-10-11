using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Data.Entities.ProductCategory;

namespace TheWebShop.Data.Entities.Category
{
    public interface ICategoryEntity : IBaseEntity
    {
        string Name { get; set; }

        string Description { get; set; }

        int? ParentCategoryEntityId { get; set; }
        
        CategoryEntity ParentCategory { get; set; }

        ICollection<CategoryEntity> ChildCategories { get; set; }

        ICollection<ProductCategoryEntity> Products { get; set; }
    }
}
