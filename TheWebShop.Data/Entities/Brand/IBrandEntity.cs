using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.Brand
{
    public interface IBrandEntity : IBaseEntity
    {
        string Name { get; set; }

        double Rating { get; }

        int RatingCount { get; }

        ICollection<ProductEntity> Products { get; set; }
    }
}
