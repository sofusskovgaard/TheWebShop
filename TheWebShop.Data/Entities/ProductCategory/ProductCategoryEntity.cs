using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using TheWebShop.Data.Entities.Category;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.ProductCategory
{
    [Table("ProductCategories")]
    public class ProductCategoryEntity : BaseEntity, IProductCategoryEntity
    {
        public int? ProductEntityId { get; set; }

        public ProductEntity Product { get; set; }

        public int? CategoryEntityId { get; set; }

        public CategoryEntity Category { get; set; }
    }
}
