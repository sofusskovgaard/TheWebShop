using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.Brand
{
    public class BrandEntity : BaseEntity, IBrandEntity
    {
        public string Name { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}
