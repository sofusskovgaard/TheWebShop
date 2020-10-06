﻿using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Data.Entities.Brand;
using TheWebShop.Data.Entities.ProductCategory;
using TheWebShop.Data.Entities.ProductPicture;

namespace TheWebShop.Data.Entities.Product
{
    public class ProductEntity : BaseEntity, IProductEntity
    {
        public string Name { get; set; }

        public int? BrandEntityId { get; set; }

        public BrandEntity Brand { get; set; }

        public double Price { get; set; }

        public ICollection<ProductPictureEntity> Pictures { get; set; }

        public ICollection<ProductCategoryEntity> Categories { get; set; }
    }
}