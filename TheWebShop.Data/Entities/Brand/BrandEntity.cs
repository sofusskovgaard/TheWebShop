using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.Brand
{
    [Table("Brands")]
    public class BrandEntity : BaseEntity, IBrandEntity
    {
        public string Name { get; set; }

        public double Rating => RatingCount > 0 ? RatingCount / Products.SelectMany(x => x.Reviews).Sum(x => x.Rating) : 0;

        public int RatingCount => Products.SelectMany(x => x.Reviews).Count();

        public ICollection<ProductEntity> Products { get; set; }
    }
}
