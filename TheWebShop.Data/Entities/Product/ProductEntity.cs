using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using TheWebShop.Data.Entities.Brand;
using TheWebShop.Data.Entities.ProductCategory;
using TheWebShop.Data.Entities.ProductPicture;
using TheWebShop.Data.Entities.Review;

namespace TheWebShop.Data.Entities.Product
{
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

        public ICollection<ReviewEntity> Reviews { get; set; }
    }
}
