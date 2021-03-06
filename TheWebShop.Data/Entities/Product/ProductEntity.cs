﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        
        public string Description { get; set; }

        public int? BrandEntityId { get; set; }

        public BrandEntity Brand { get; set; }

        [Column("decimal(5,2)")]
        public decimal Price { get; set; }

        public ICollection<ProductPictureEntity> Pictures { get; set; }

        public ICollection<ProductCategoryEntity> Categories { get; set; }

        public decimal Rating => RatingCount > 0 ? Decimal.Divide(Reviews.Sum(x => x.Rating), RatingCount) : 0;

        public int RatingCount => Reviews?.Count ?? 0;
        
        public bool Highlight { get; set; }

        public bool InStock => Stock > 0;
        
        public int Stock { get; set; }

        public ICollection<ReviewEntity> Reviews { get; set; }
    }
}
